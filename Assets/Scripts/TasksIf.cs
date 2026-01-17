using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksIf : MonoBehaviour
{
    public int number = 10;

    private void Start()
    {
        if (number > 0)
        {
            Debug.Log("Положительный");
        }
        else if (number < 0)
        {
            Debug.Log("Отрицательный");
        }
        else
        {
            Debug.Log("Ноль");
        }
    }
}
