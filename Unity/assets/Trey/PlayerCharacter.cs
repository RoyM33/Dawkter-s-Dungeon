using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character
{
    public PlayerViewOptions ViewOption = PlayerViewOptions.OverTheShoulder;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
