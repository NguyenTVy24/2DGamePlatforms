using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDivision : MonoBehaviour
{
    public GameObject Cell;
    public int Quantity = 5;
    private int quantity;
    public float range = 0.5f;
    private int waychooes;
    private EnemyMovement enemyMovement;
    void Start(){
        enemyMovement = GetComponent<EnemyMovement>();
        StartCoroutine(SetTaget());
        quantity = Quantity;
    }
    IEnumerator SetTaget(){
        yield return new WaitForSeconds(0.01f);
        waychooes = enemyMovement.GetWayChoose();
    }
    public void Celldivision(){
        Debug.Log("goi ham");
        for(int i = 0; i <quantity; i++){
            GameObject cell = (GameObject)Instantiate(Cell, transform.position + new Vector3(Random.Range(-range,range),0,Random.Range(-range,range)), transform.rotation);
            EnemyMovement cellEnemy = cell.GetComponent<EnemyMovement>();
            cellEnemy.SetTaget(waychooes,enemyMovement.GetWavepointIndex());
            cellEnemy.SetWavepointIndex(enemyMovement.GetWavepointIndex());
        }
    }
}
