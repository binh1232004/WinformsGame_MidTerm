using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager1 : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    // what code above mean SerializeField?
    // SerializeField is a Unity attribute that allows a variable to be serialized into the inspector without making it public.
    //what is TMP_Text?
    // TextMeshPro is a replacement for Unity's existing text components like Text Mesh and UI Text. It uses an advanced text rendering technique known as signed distance field rendering, which allows it to maintain crispness regardless of screen resolution.


    [SerializeField] private TMP_Text _newBestText;
    [SerializeField] private TMP_Text _bestScoreText;

    private void Awake()
    {

        _bestScoreText.text = GameManager.Instance.HighScore.ToString();
        if(!GameManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());

        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        //what is current score in Instance
        //CurrentScore is a method that return the current score.
        int highScore = GameManager.Instance.HighScore;

        if(highScore < currentScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }
        _bestScoreText.text = GameManager.Instance.HighScore.ToString();





        float speed = 1 / _animationTime;
        float timeElapsed = 0f;

        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();

    }

    [SerializeField] private AudioClip _clickClip;

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToGameplayGame1();
    }
    public void ClickedReturn(){
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToBase();
    }
}
