using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainMenu";
    public SceneFader sceneFader;
    public void Play(){
        sceneFader.FadeTo(levelToLoad);
    }
    public void Quit(){
        Debug.Log("Exciting........");
        Application.Quit();
    }
}
