using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton MonoBehaviour implementation that keeps objects alive even between scenes.
/// 
/// If class inherits from here, the base.Awake method needs to be called from the childs Awake method. 
/// This keeps the object a singleton and alive over scenes.
/// </summary>
/// <typeparam name="T">Type of class that uses inheritance from this class</typeparam>
public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject coreGameObject = new GameObject(typeof(T).Name);

                _instance = coreGameObject.AddComponent<T>();
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<T>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
