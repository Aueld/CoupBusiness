using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }

    public GameObject obj;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
            Application.Quit();
        else
            return;
    }
}
