using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public Character MainCharacter;
    public GameState _gameState = GameState.Intro;

    private Texture YouWinTexture;
    private Texture YouLoseTexture;

    private AudioClip _onLoseSound;

    // Use this for initialization
    void Start()
    {
        if (MainCharacter == null)
        {
            MainCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        }

        YouWinTexture = Resources.Load<Texture>("Images/YouWin");
        YouLoseTexture = Resources.Load<Texture>("Images/YouLose");

        this.EnsureComponent<AudioSource>();

        _onLoseSound = Resources.Load<AudioClip>("Sounds/onLose");
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.Intro:
                _gameState = GameState.InProgress;
                break;


            case GameState.InProgress:
                if (MainCharacter.Health <= 0)
                {
                    _gameState = GameState.Lose;
                    audio.PlayOneShot(_onLoseSound);
                }
                break;


            case GameState.Win:
                break;


            case GameState.Lose:
                break;
        }
    }

    void OnGUI()
    {
        if (_gameState == GameState.Win)
        {
            GUI.DrawTexture(new Rect(0, 0, 327, 191), YouWinTexture);
        }

        switch (_gameState)
        {
            case GameState.Intro:
                _gameState = GameState.InProgress;
                break;


            case GameState.InProgress:

                break;


            case GameState.Win:
                GUI.DrawTexture(new Rect(0, 0, 327, 191), YouWinTexture);
                break;


            case GameState.Lose:
                GUI.DrawTexture(new Rect(0, 0, 372, 191), YouLoseTexture);
                break;
        }
    }
}

public enum GameState
{
    Intro, InProgress, Win, Lose
}