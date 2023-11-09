using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject GameOverUI;

    public GameObject completeLevelUI;

    public SceneFader sceneFader;
    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if(GameIsOver) return;
        if(PlayerStats.Lives <= 0){
            EndGame();
        }
    }
    void EndGame(){
        GameIsOver = true;
        GameOverUI.SetActive(true);
    }
    public void WinLevel(){
       completeLevelUI.SetActive(true);
    }
}
