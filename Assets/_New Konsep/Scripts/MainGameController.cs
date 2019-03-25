using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour {
    private static MainGameController instance;
    public static MainGameController TheInstanceOfMainGameController
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MainGameController>();
            }
            return instance;
        }
    }

    [Header("Timer Component")]
    public Slider TimerSliderGo;
    public Text TimerText;
    public float TimeToCountDown;
    private float time;


    [Header("Menu Component")]
    public GameObject MenuWinGame;
    public GameObject MenuLoseGame;
    public GameObject AllGameObject;
    [Space(25)]
    public Button AnimalImageButtonWinMenu;
    public Image AnimalImageLoseMenu;
    [Space(20)]
    public Text ScoreTextWin;
    public Text ScoreTextLose;
    [HideInInspector]
    public int PlayerScore;
    private bool InMenu;


    private void Start()
    {
        InitializeGame();
        PlayerScore = 0;
    }

    private void Update()
    {
        if ( time > 0 && !InMenu)
        {
            time -= Time.deltaTime;
            TimerText.text = time.ToString("f0");
            TimerSliderGo.value = time;
        }

        if(time <= 0)
        {
            Debug.Log("Time Out You Lose");
            GameMaster.TheInstanceOfGameMaster.LoseGame();
        }
    }

    public void InitializeGame()
    {
        StartCoroutine(WaitInitialize());
    }

    IEnumerator WaitInitialize()
    {
        yield return new WaitForSecondsRealtime(.1f);
        MenuWinGame.SetActive(false);
        MenuLoseGame.SetActive(false);
        AllGameObject.SetActive(true);
        ResetTimer();
        InMenu = false;
    }

    public void ResetTimer()
    {
        time = TimeToCountDown;
        TimerSliderGo.maxValue = time;
        TimerSliderGo.value = time;
    }

    public void WinGameConditions()
    {
        Debug.Log("You Win");
        MenuWinGame.SetActive(true);
        MenuLoseGame.SetActive(false);
        AllGameObject.SetActive(false);
        InMenu = true;
        PlayerScore += 10;
        ScoreTextWin.text = PlayerScore.ToString();
    }

    public void LoseGameConditions()
    {
        Debug.Log("You Lose");
        MenuWinGame.SetActive(false);
        MenuLoseGame.SetActive(true);
        AllGameObject.SetActive(false);
        InMenu = true;
        ScoreTextLose.text = PlayerScore.ToString();
    }
}
