using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ways : MonoBehaviour
{
    public static Waypoints[] waypoints;
    void Awake(){
        waypoints = new Waypoints[transform.childCount];
        for(int i=0; i < waypoints.Length; i++){
            waypoints[i] = transform.GetChild(i).GetComponent<Waypoints>();
        }
    }
}
