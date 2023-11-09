using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader sceneFader;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
            Toggel();
        }
    }
    public void Toggel(){
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }
    public void Retry(){
        Toggel();
        sceneFader.FadeTo((SceneManager.GetActiveScene().buildIndex-1).ToString());
    }
    public void Menu(){
        Toggel();
        sceneFader.FadeToMainMenu();
    }
}
