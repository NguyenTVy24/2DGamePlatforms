using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float timespaws = 5f;
    public GameObject Pet;
    private float countdown;
    private EnemyMovement enemyMovement;
    private Enemy enemy;
    private int waychooes;
    private int go;
    void Start(){
        countdown = timespaws;
        enemyMovement = GetComponent<EnemyMovement>();
        enemy = GetComponent<Enemy>();
        StartCoroutine(SetTaget());
        go = 0;
    }
    IEnumerator SetTaget(){
        yield return new WaitForSeconds(0.01f);
        waychooes = enemyMovement.GetWayChoose();
    }
    void Update(){
        if(enemy.GetHealth() <= enemy.startHealth/2 && go==0){
            timespaws = 0.8f;
            enemy.startSpeed *=2f;
            go = 1;
        }
        if(enemy.GetHealth() <= enemy.startHealth/5 && go==1){
            timespaws = 0.6f;
            enemy.startSpeed *=2f;
            go = 2;
        }
        if(enemy.GetHealth() <= enemy.startHealth/8 && go==2){
            timespaws = 0.5f;
            enemy.startSpeed *=2f;
            go = 3;
        }
        if(enemy.GetHealth() <= enemy.startHealth/20 && go==3){
            timespaws = 0.4f;
            enemy.startSpeed *=2f;
            go = 4;
        }
        if(countdown <= 0f){
            GameObject pet = (GameObject)Instantiate(Pet, transform.position, transform.rotation);
            EnemyMovement petEnemy = pet.GetComponent<EnemyMovement>();
            petEnemy.SetTaget(waychooes,enemyMovement.GetWavepointIndex());
            petEnemy.SetWavepointIndex(enemyMovement.GetWavepointIndex());
            countdown = timespaws;
        }
        countdown -= Time.deltaTime;
    }
}
