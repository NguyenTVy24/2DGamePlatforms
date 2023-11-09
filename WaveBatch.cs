using UnityEngine;

[System.Serializable]
public class WaveBatch
{
    public Wave[] waves;
    public float Waverate;
    public int NumberOfEnemies(){
        int numberOfEnemies = 0;
        foreach(Wave wave in waves){
            numberOfEnemies+= wave.count*wave.waychooes.Length;
        }
        return numberOfEnemies;
    }
}
