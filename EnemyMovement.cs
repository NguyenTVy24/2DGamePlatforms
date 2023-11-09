using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform taget;
    private int wavepointIndex = 0;
    private Enemy enemy;
    private int wayChoose = 0;
    private bool stop = false;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void SetTaget(int wayChoose , int index = 0){
        this.wayChoose = wayChoose;
        taget = Ways.waypoints[wayChoose].Points[index];
    }
    public int GetWavepointIndex(){
        return wavepointIndex;
    }
    public int GetWayChoose(){
        return wayChoose;
    }
    public void SetWavepointIndex(int wavepointIndex){
        this.wavepointIndex = wavepointIndex;
    }
    void Update()
    {
        if(stop) return;

        Vector3 dir = taget.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, taget.position)<= 0.5f){
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWaypoint(){
        if(wavepointIndex >= Ways.waypoints[wayChoose].Points.Length -1){
            EndPath();
            return;
        }

        wavepointIndex++;
        taget = Ways.waypoints[wayChoose].Points[wavepointIndex];

    }
    void EndPath(){
        if(GetComponent<Boss3>()){
            GetComponent<Boss3>().SetSpawsn();
            stop = true;
            return;
        }
        PlayerStats.Lives -= enemy.damageToPlayer;
        if(!enemy.ispet){
            WaveSpawner.EnemiesAlive--;
        }
        Destroy(gameObject);
    }
}
