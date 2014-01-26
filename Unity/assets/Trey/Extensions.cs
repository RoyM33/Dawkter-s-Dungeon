using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Extensions
{

    public static T EnsureComponent<T>(this GameObject gameObj) where T : Component
    {
        T component = gameObj.GetComponent<T>();

        if (component == null)
            component = gameObj.AddComponent<T>();

        return component;
    }

    public static T EnsureComponent<T>(this MonoBehaviour behavior) where T : Component
    {
        return behavior.gameObject.EnsureComponent<T>();
    }


    public static IEnumerable<GameObject> GetChildren(this GameObject gameObject)
    {
        foreach (Transform transform in gameObject.transform)
        {
            yield return transform.gameObject;
        }
    }

    public static void DrawCentered(this Texture texture)
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - texture.width / 2, Screen.height / 2 - texture.height / 2, texture.width, texture.height), texture);
    }

}
