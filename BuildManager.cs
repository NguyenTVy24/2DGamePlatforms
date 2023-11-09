using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake(){
        if(instance != null){
            Debug.LogError("nhieu hon 1 buildManaher trong mang");
            return;
        }
        instance = this;
    }
    public GameObject buildEffect;
    public GameObject sellEffect;
    public GameObject sellEffectUpgraded;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    
    public bool Canbuild { get { return turretToBuild != null; }}
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }}
    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
        selectedNode = null;
        DeselectedNode();
    }
    public void SelectNode(Node node){
        if(selectedNode == node){
            DeselectedNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselectedNode(){
        selectedNode = null;
        nodeUI.Hide();
    }
    public TurretBlueprint GetTurretBlueprint(){
        return turretToBuild;
    }
}
