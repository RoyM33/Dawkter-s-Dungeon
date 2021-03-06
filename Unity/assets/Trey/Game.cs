﻿using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public Character MainCharacter;
    public GameState _gameState = GameState.Intro;

    private Texture YouWinTexture;
    private Texture YouLoseTexture;

    private Texture Ready0;
    private Texture Ready1;
    private Texture Ready2;
    private Texture Ready3;

    private Character Boss;

    private AudioClip _onLoseSound;

    private float IntroStart;
    public float TimeSinceStart
    {
        get
        {
            return Time.realtimeSinceStartup - IntroStart;
        }
    }

    // Use this for initialization
    void Start()
    {
        if (MainCharacter == null)
        {
            MainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        }

        YouWinTexture = Resources.Load<Texture>("Images/YouWin");
        YouLoseTexture = Resources.Load<Texture>("Images/YouLose");
        Ready0 = Resources.Load<Texture>("Images/0");
        Ready1 = Resources.Load<Texture>("Images/1");
        Ready2 = Resources.Load<Texture>("Images/2");
        Ready3 = Resources.Load<Texture>("Images/3");

        this.EnsureComponent<AudioSource>();

        _onLoseSound = Resources.Load<AudioClip>("Sounds/onLose");

        Time.timeScale = 0;
        IntroStart = Time.realtimeSinceStartup;

        Screen.showCursor = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.Intro:


                if (TimeSinceStart > 4)
                {
                    Time.timeScale = 1;
                    _gameState = GameState.InProgress;
                }
                break;


            case GameState.InProgress:
                if (gameover)
                    return;

                if (MainCharacter.Health <= 0)
                {
                    gameover = true;
                    StartCoroutine(WaitAndLose());
                    audio.PlayOneShot(_onLoseSound);
                }


                if (Boss == null)
                {
                    var bossObj = GameObject.FindGameObjectWithTag("Boss");
                    if (bossObj)
                        Boss = bossObj.GetComponent<Character>();
                }
                else
                {
                    if (Boss.Health <= 0)
                    {
                        gameover = true;
                        StartCoroutine(WaitAndWin());
                    }
                }


                break;


            case GameState.Win:

                break;


            case GameState.Lose:
                break;
        }
    }

    private bool gameover = false;

    IEnumerator WaitAndWin()
    {
        yield return new WaitForSeconds(2);

        _gameState = GameState.Win;
        Time.timeScale = 0;

        StartCoroutine(WaitAndReload());
    }

    IEnumerator WaitAndReload()
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + 8f)
        {
            yield return null;
        }
        Application.LoadLevel(0);
    }

    IEnumerator WaitAndLose()
    {
        yield return new WaitForSeconds(2);

        _gameState = GameState.Lose;
        Time.timeScale = 0; 
        
        StartCoroutine(WaitAndReload());
    }

    void OnGUI()
    {
        switch (_gameState)
        {
            case GameState.Intro:
                if (TimeSinceStart > 3)
                    Ready1.DrawCentered();
                else if (TimeSinceStart > 2)
                    Ready2.DrawCentered();
                else if (TimeSinceStart > 1)
                    Ready3.DrawCentered();
                else
                    Ready0.DrawCentered();
                break;


            case GameState.InProgress:

                break;


            case GameState.Win:
                YouWinTexture.DrawCentered();
                break;


            case GameState.Lose:
                YouLoseTexture.DrawCentered();
                break;
        }
    }
}

public enum GameState
{
    Intro, InProgress, Win, Lose
}