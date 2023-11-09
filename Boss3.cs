using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public float timespaws = 5f;
    public GameObject[] Pets;
    private GameObject Pet;
    private float countdown;
    private EnemyMovement enemyMovement;
    private Enemy enemy;
    private int go;
    private bool setActiveSpawn = false;
    void Start(){
        countdown = timespaws;
        enemyMovement = GetComponent<EnemyMovement>();
        enemy = GetComponent<Enemy>();
        go = 0;
        Pet = Pets[0];
    }
    void Update(){
        if(!setActiveSpawn) return;
        if(enemy.GetHealth() <= enemy.startHealth/1.5 && go==0){
            timespaws *= 0.5f;
            Pet = Pets[1];
            go = 1;
        }
        if(enemy.GetHealth() <= enemy.startHealth/3 && go==1){
            timespaws *= 0.5f;
            Pet = Pets[0];
            go = 2;
        }
        if(enemy.GetHealth() <= enemy.startHealth/9 && go==2){
            Pet = Pets[1];
            go = 3;
        }
        if(countdown <= 0f){
            for(int i=0; i<2; i++){
                GameObject pet = (GameObject)Instantiate(Pet, transform.position, transform.rotation);
                EnemyMovement petEnemy = pet.GetComponent<EnemyMovement>();
                petEnemy.SetTaget(i+4,0);   
            }
            countdown = timespaws;
        }
        countdown -= Time.deltaTime;
    }
    public void SetSpawsn(){
        setActiveSpawn = true;
    }
}
