using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    #region START
    private bool hasGameFinished;
    public static GameplayManager Instance;
    public List<Color> Colors;
    private void Awake()
    {
        Instance = this;
        hasGameFinished = false;
        GameManager.Instance.IsInitialized = true;
        score = 0;
        _scoreText.text = score.ToString();
        StartCoroutine(SpawnScore()); 
    }
    #endregion

    #region GAME_LOGIC
    [SerializeField] private ScoreEffect _scoreEffect;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasGameFinished)
        {
            if(CurrentScore == null)
            {
                //GameEnded();
                return;
            }
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                
            if (!hit.collider)
            {
               /* GameEnded();*/
                return;
            }
            if (!hit.collider.CompareTag("Block"))
            {
                /*GameEnded();*/
                return;
            }
            int currentScoreId = CurrentScore.ColorId;
            int clickedScoreId = hit.collider.gameObject.GetComponent<Player>().ColorId;

            if(currentScoreId != clickedScoreId)
            {
                return;
            }
            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;
            if (CurrentScore.NextScore != null)
            {
                CurrentScore = tempScore.NextScore;
            }
            Destroy(tempScore.gameObject);
            UpdateScore();
        }
    }
    #endregion

    #region SCORE
    private int score; // float
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private AudioClip _pointClip;
    public void UpdateScore()
    {
        score++;
        SoundManager.Instance.PlaySound(_pointClip);
        _scoreText.text = score.ToString();
    }
    [SerializeField] private float _spawnTime;
    [SerializeField] private Score _scorePrefab;
    private Score CurrentScore;

    private IEnumerator SpawnScore()
    {
        Score prevScore = null;
        while (!hasGameFinished)
        {
            var tempScore = Instantiate(_scorePrefab);
           
            if(prevScore == null)
            {
                CurrentScore = tempScore;
                prevScore = tempScore;
            }
            else
            {
                prevScore.NextScore = tempScore;
                prevScore = tempScore;
            }
            //Spawn block ra sau 1 kho?ng tgian
            yield return new WaitForSeconds(_spawnTime);
        }
    }
    #endregion

    #region GAME_OVER
    
    [SerializeField] private AudioClip _loseClip;
    
    public UnityAction GameEnd;
    public void GameEnded()
    {
        GameEnd?.Invoke();
        SoundManager.Instance.PlaySound(_loseClip);
        hasGameFinished = true;
        GameManager.Instance.CurrentScore = score;
        StartCoroutine(GameOver());
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GoToMainMenuGame2();
    }
    #endregion
}
