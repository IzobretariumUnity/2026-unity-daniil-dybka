using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start");
        HelloWorld();
    }

    private void Update()
    {
        HelloWorld();
    }

    private void HelloWorld()
    {
        Debug.Log("Hello World!");
    }
}
