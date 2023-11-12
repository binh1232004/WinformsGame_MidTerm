using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _newBestText;
    private void Awake()
    {
        if (GameManager.Instance.IsInitialized)
        {
            StartCoroutine(ShowScore()); 
        }
        else
        {
            _newBestText.gameObject.SetActive(false); // neu moi choi lan dau
            _scoreText.gameObject.SetActive(false);
            _highScoreText.text = GameManager.Instance.HighScore.ToString();
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve; 
    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();
        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;
        if (currentScore > highScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }
        _highScoreText.text = GameManager.Instance.HighScore.ToString();
        //d? ?o�n th? t? thao t�c ?i?m ng??i ch?i d?a tr�n animationTime c�i tr??c
        
        float speed = 1 / _animationTime;
        float timeElapsed = 0f;
        while (timeElapsed < 1f)
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
        GameManager.Instance.GoToGameplayGame2();
    } 

    public void ClickedReturn()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToBase();
    } 
}
