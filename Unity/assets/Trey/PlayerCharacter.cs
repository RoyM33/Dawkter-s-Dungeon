using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character
{
    public PlayerViewOptions ViewOption = PlayerViewOptions.TopDown;

    private CharacterMotor _motor;

    public float TopDownSpeed = 15;
    public float FirstPersonSpeed = 8;
    private GUIStyle style = new GUIStyle();
    // Use this for initialization
    void Start()
    {
        Texture2D healthBackground = new Texture2D(1, 1);
        healthBackground.SetPixel(1, 1, Color.red);
        healthBackground.Apply();
        style.normal.background = healthBackground;
        _motor = this.GetComponent<CharacterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            this.GetComponent<CharacterMotor>().enabled = false;
            return;
        }

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
            _motor.movement.maxBackwardsSpeed = TopDownSpeed;
            _motor.movement.maxForwardSpeed = TopDownSpeed;
            _motor.movement.maxSidewaysSpeed = TopDownSpeed;
        }
        else
        {
            _motor.movement.maxBackwardsSpeed = FirstPersonSpeed;
            _motor.movement.maxForwardSpeed = FirstPersonSpeed;
            _motor.movement.maxSidewaysSpeed = FirstPersonSpeed;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width * Health / 100, 30), Health.ToString(), style);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.name.Equals("Bullet(Clone)"))
		{
			Health -= 8;//10 shots to kill
		}
	}

}

public enum PlayerViewOptions
{
    TopDown, OverTheShoulder
}
