using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;


    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    // Update is called once per frame
    public Vector3 GetBuildPosition(){
        return transform.position + positionOffset;
    }
    void BuildTurret (TurretBlueprint blueprint){
        if(PlayerStats.Money < blueprint.cost){
            Debug.Log("khong du tien");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        turretBlueprint = blueprint;    
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Debug.Log("Xay thanh cong");
    }
    public void UpgradeTurret (){
        if(PlayerStats.Money < turretBlueprint.upgradeCost){
            Debug.Log("khong du tien nang cap");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        //huy phao cu
        Destroy(this.turret);
        //tao phao moi 
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        isUpgraded = true;

        Debug.Log("Nang cap thanh cong");
    }
    public void SellTurret(){
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        if(!isUpgraded){
            GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
        }else{
            GameObject effect = (GameObject)Instantiate(buildManager.sellEffectUpgraded, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 5f);
        }
        Destroy(turret);
        turretBlueprint = null;
    }
    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(!buildManager.Canbuild){
            return;
        }
        if(buildManager.HasMoney){
            rend.material.color = hoverColor;
        }else{
            rend.material.color = notEnoughMoneyColor;
        }
        
    }
    void OnMouseExit(){
        rend.material.color = startColor;
    }
    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        
        if(turret != null){
            buildManager.SelectNode(this);
            return;
        }
        if(!buildManager.Canbuild){
            return;
        }
        //xay dung phao
        BuildTurret(buildManager.GetTurretBlueprint());
    }
}
