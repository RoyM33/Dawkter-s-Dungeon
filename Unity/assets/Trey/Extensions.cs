using UnityEngine;
using System.Collections;

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
}
