using UnityEngine.SceneManagement;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    private string nextLevel;
    private int levelToUnlock;
    void Start(){
        levelToUnlock = SceneManager.GetActiveScene().buildIndex;
        nextLevel = levelToUnlock.ToString();
    }
    public void Continue(){
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
    public void Menu(){
        sceneFader.FadeToMainMenu();
    }
}
