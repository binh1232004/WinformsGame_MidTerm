using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName3 = "MainMenuGame3"; // Tên của Scene mà bạn muốn load
    public string sceneName2 = "MainMenuGame2"; // Tên của Scene mà bạn muốn load
    public string sceneName1 = "MainMenuGame1"; // Tên của Scene mà bạn muốn load


    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName3);
    }
    public void LoadSceneGame1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName2);
    }


}
