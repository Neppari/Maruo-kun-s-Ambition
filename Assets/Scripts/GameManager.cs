using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var gameObj = new GameObject(nameof(GameManager));
                _instance = (GameManager)gameObj.AddComponent(typeof(GameManager));
            }

            return _instance;
        }
        set
        {
            if (_instance == null)
            {
                _instance = value;
            }
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.Log("Too many GameManagers, deleting this");
            GameObject.Destroy(gameObject);
        }
    }
}
