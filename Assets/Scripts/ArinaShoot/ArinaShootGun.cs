using System.Collections;
using UnityEngine;

public class ArinaShootGun : MonoBehaviour
{
    [Header("Пуля")]
    public GameObject bullet;

    [Header("Точка для появления пули")]
    public Transform pointToSpawn;

    [Header("Задержка между выстрелами")]
    public float delayToSpawn = 2f;

    [Header("Будет ли следить пистолет за игроком")]
    public bool gunTowardPlayer = false;

    [Header("Скорость поворота к игроку")]
    public float rotationSpeed = 5f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    private void FixedUpdate()
    {
        if (!gunTowardPlayer || player == null) return;

        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayToSpawn);
            Instantiate(bullet, pointToSpawn.position, pointToSpawn.rotation);
        }
    }
}
