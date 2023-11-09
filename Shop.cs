using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint turretSky;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;
    void Start (){
        buildManager = BuildManager.instance;
    }
    public void SelectStadardTurret(){
        Debug.Log("StadardTurret");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectTurretSky(){
        Debug.Log("TurretSky");
        buildManager.SelectTurretToBuild(turretSky);
    }
    public void SelectMissileLaucher(){
        Debug.Log("MissileLaucher");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer(){
        Debug.Log("LaserBeamer");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
