using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [Range(0.0f, 2.0f)]
    public float time = 1f;

    private void Update()
    {
        Time.timeScale = time;
    }
}
