using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character
{
    public PlayerViewOptions ViewOption = PlayerViewOptions.TopDown;

    private CharacterMotor _motor;

    // Use this for initialization
    void Start()
    {
        _motor = this.GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ViewOption == PlayerViewOptions.TopDown)
            {
                ViewOption = PlayerViewOptions.OverTheShoulder;
            }
            else
            {
                ViewOption = PlayerViewOptions.TopDown;
            }
        }

        if (ViewOption == PlayerViewOptions.TopDown)
        {
            _motor.movement.maxBackwardsSpeed = 20;
            _motor.movement.maxForwardSpeed = 20;
            _motor.movement.maxSidewaysSpeed = 20;
        }
        else
        {
            _motor.movement.maxBackwardsSpeed = 5;
            _motor.movement.maxForwardSpeed = 5;
            _motor.movement.maxSidewaysSpeed = 5;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width * Health / 100, 30), Health.ToString());
    }
}


public enum PlayerViewOptions
{
    TopDown, OverTheShoulder
}
