using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

    public Character MainCharacter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void OnGUI()
    {
        if (MainCharacter.Health <= 0)
        {
            GUI.TextArea(new Rect(0, 0, 200, 45), "You lose!!!");
        }
        else
        {
            GUI.TextArea(new Rect(0, 0, 200, 45), "You're alive!");
        }
    }
}
