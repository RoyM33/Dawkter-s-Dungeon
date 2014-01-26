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
        switch (_gameState)
        {
            case GameState.Intro:
                _gameState = GameState.InProgress;
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