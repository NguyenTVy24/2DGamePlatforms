using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{   
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public bool ispet = false;

    public float startHealth = 100f;
    private float health;

    public int worth = 50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;
    public int damageToPlayer = 1;
    private bool isDead = false;
    void Start (){
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount){

        health -= amount;
        
        healthBar.fillAmount = health/startHealth;

        if(health <= 0 && !isDead){
            Die();
        }
    }
    public void Slow(float pct){
        speed = speed * (1f - pct);
    }
    public float GetHealth(){
        return health;
    }
    void Die(){
        isDead = true;
        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        if(GetComponent<CellDivision>()){
            GetComponent<CellDivision>().Celldivision();
        }
        Destroy(effect,5f);
        if(!ispet){
            WaveSpawner.EnemiesAlive--;
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    
    
}
