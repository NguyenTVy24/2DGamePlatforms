using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive ;
    [Header("Setting")]
    public float timeBetweenWaves = 5f;
    public Transform[] spawnPoint;
    public Text waveCountdownText;
    public int waveBatchesIndex = 0;
    private float countdown = 2f;
    public GameManager gameManager;
    [Header("Setup WaveBatches")]
    public GameObject[] enemies;
    public WaveBatch[] waveBatches;
    
    // Update is called once per frame
    void Start(){
        EnemiesAlive = 0;
    }
    void Update()
    {
        Debug.Log(EnemiesAlive);
        if(EnemiesAlive > 0){
            return;
        }
        if(GameManager.GameIsOver){
            return;
        }
        if(waveBatchesIndex == waveBatches.Length){
            gameManager.WinLevel();
            this.enabled = false;
        }
        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        
        countdown -=  Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave(){  
        PlayerStats.Rounds++;
        WaveBatch waveBatch = waveBatches[waveBatchesIndex];
        EnemiesAlive = waveBatch.NumberOfEnemies();
        foreach(Wave wave in waveBatch.waves){
            for(int i=0;i < wave.count ; i++){
                for(int y=0;y < wave.waychooes.Length;y++){
                    SpawnEnemy(enemies[wave.enemyIndex],wave.waychooes[y]);
                }
                yield return new WaitForSeconds( 1f / wave.rate);
            }
            yield return new WaitForSeconds( 1f / waveBatch.Waverate);
        }
        waveBatchesIndex++;
    }
    void SpawnEnemy(GameObject enemy,int waychooes){
        GameObject e = (GameObject)Instantiate(enemy, spawnPoint[waychooes].position, spawnPoint[waychooes].rotation);
        EnemyMovement enemyMovement = e.GetComponent<EnemyMovement>();
        enemyMovement.SetTaget(waychooes);
    }
}
