using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth = 3;

    private string playerPrefsKey = "health";

    private void Start()
    {
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            health = PlayerPrefs.GetInt(playerPrefsKey);
        }
        else
        {
            health = maxHealth;
        }
    }

    public void HealthAdd()
    {
        HealthChange(1);
    }

    public void HealthMinus()
    {
        HealthChange(-1);
    }

    private void HealthChange(int valueChange)
    {
        health += valueChange;
        PlayerPrefs.SetInt(playerPrefsKey, health);

        if (health > maxHealth)
        {
            health = maxHealth;
            PlayerPrefs.SetInt(playerPrefsKey, maxHealth);
        }

        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            PlayerPrefs.DeleteKey(playerPrefsKey);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
