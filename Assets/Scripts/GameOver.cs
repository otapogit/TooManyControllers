using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public GameObject gameoverpanel;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    public void ShowGameOver(){
        gameoverpanel.SetActive(true);
    }
    // Start is called before the first frame update
    public void RestartScene(){
        //SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        Application.Quit();
    }
}
