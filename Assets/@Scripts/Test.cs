using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(GameManager.Instance.Dir);
    }
}
