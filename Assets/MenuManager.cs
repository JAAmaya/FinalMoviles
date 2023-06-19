using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject InGameMenu;
    // Start is called before the first frame update
        // Update is called once per frame
    public void showInGameMenu(){
        Time.timeScale = 0;
        InGameMenu.SetActive(true);
    }
    public void hideInGameMenu(){
        Time.timeScale = 1;
        InGameMenu.SetActive(false);
    }
    public void loadSceneButton(string sceneName){
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
