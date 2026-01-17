using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    int a = 5;
    float b = 4.5f;
    string text = "Hello, World!";
    bool active = true;

    // private void Start()
    // {
    //     double a = Math.Pow(45, 3) * 400 - 256;
    //     double b = Math.Pow(2041, 2) - Math.Pow(400, 3);
    //     double result = a / b;
    //     Debug.Log(result);
    // }

    int counter = 0;

    private void Update()
    {
        counter += 1;

        Debug.Log("Счетчик: " + counter);
    }
}
