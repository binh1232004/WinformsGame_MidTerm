using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //Khi chuy?n gi?a c�c scene gameObject ko b? h?y t? ??ng m� v?n t?n t?i
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private const string highScoreKey = "HighScore";
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }

        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }
    public bool IsInitialized { get; set; }
    public int CurrentScore { get; set; }
    public void Init()
    {
        CurrentScore = 0;
        IsInitialized = false;
    }
    private const string Base = "SampleScene";
    
    private const string MainMenu1 = "MainMenuGame1";
    private const string MainMenu2 = "MainMenuGame2";
    private const string MainMenu3 = "MainMenuGame3";

    private const string GameplayGame2 = "GameplayGame2";
    private const string GameplayGame1 = "GameplayGame1";
    public void GoToMainMenuGame1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu1);
    }
       public void GoToGameplayGame1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameplayGame1);
    }


    public void GoToMainMenuGame2()
    {
        //Load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu2);
    }
      public void GoToGameplayGame2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameplayGame2);
    }


    /*public void GoToMainMenuGame3()
    {
        //Load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu3);
    }*/
  

    public void GoToBase()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Base);
    }
   /* public void GoToBase()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene();
    }*/
}
