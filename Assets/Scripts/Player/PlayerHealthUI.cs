using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public GameObject prefabHealth;
    public float space = 140f;
    public bool moveRight = true;

    private string healthParent = "ui_HealthBar";

    private GameObject parent;
    private List<GameObject> objectsHealth = new List<GameObject>();

    private void Start()
    {
        ParentInit();
    }

    public void InitUI(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if (parent == false) ParentInit();

            GameObject initPrefabHealth = Instantiate(prefabHealth, parent.transform, false);

            RectTransform rt = initPrefabHealth.GetComponent<RectTransform>();
            Vector2 pos = rt.anchoredPosition;

            float dir = moveRight ? 1f : -1f;
            rt.anchoredPosition = new Vector2(pos.x + dir * i * space, pos.y);

            objectsHealth.Add(initPrefabHealth);
        }

        UpdateUI(currentHealth);
    }

    public void UpdateUI(int health)
    {
        for (int i = 0; i < objectsHealth.Count; i++)
        {
            objectsHealth[i].SetActive(i < health);
        }
    }

    private void ParentInit()
    {
        parent = GameObject.FindGameObjectWithTag(healthParent);
    }
}
