using UnityEngine;
using System.Collections;

public class StartUpGUI : MonoBehaviour {

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 250, 10, 500, 500), "Welcome To Wisper");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 40, 80, 20), "Easy"))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 70, 80, 20), "Mild"))
        {
            Application.LoadLevel(1);
        }
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 100, 80, 20), "Hard"))
        {
            Application.LoadLevel(1);
        }
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 40, 130, 80, 20), "Instructions"))
        {
            Application.LoadLevel(1);
        }

        GUI.Box(new Rect(Screen.width / 2 - 250, 160, 500, 20), "Global Game Jam 2014");

        GUI.Box(new Rect(Screen.width / 2 - 250, 190, 500, 20), "Created In 48 hours.");

        GUI.Box(new Rect(Screen.width / 2 - 250, 220, 500, 20), "Created By:");

        GUI.Box(new Rect(Screen.width / 2 - 250, 250, 500, 20), "Roy McGregor, Trey Wheeler, Mark Sebesta, Xyrus Najar");

    }
}
