using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{ 
    public SceneFader sceneFader;
    public void Retry(){
        sceneFader.FadeTo((SceneManager.GetActiveScene().buildIndex-1).ToString());
    }
    public void Menu(){
        sceneFader.FadeToMainMenu();
    }
}
