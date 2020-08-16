using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTester : MonoBehaviour
{
    void Start()
    {
        var gm = GameManager.Instance;
    }
}
