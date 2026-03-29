using UnityEngine;

public class ArinaShootBullet : MonoBehaviour
{
    [Header("Скорость пули")]
    public float speed = 20f;

    [Header("Время жизни пули (сек)")]
    public float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
