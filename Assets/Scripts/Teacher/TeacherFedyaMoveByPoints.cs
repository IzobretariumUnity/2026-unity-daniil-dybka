using UnityEngine;

public class TeacherFedyaMoveByPoints : MonoBehaviour
{
    public GameObject[] points;
    public float speed = 7f;
    public float delay = 2f;

    private int currentIndex = 0;
    private int nextIndex = 1;
    private float timer = 0f;
    private bool isWaiting = false;
    private float coordZ = 0f;

    private void Start()
    {
        if (points.Length == 0) return;
        transform.position = points[0].transform.position;
        coordZ = transform.position.z;
    }

    private void Update()
    {
        if (points.Length <= 1) return;

        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0f;
                isWaiting = false;
            }
            return;
        }

        Vector3 pp = points[nextIndex].transform.position;
        Vector3 target = new Vector3(pp.x, pp.y, coordZ);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            transform.position = target;
            currentIndex = nextIndex;
            nextIndex = (nextIndex + 1) % points.Length;
            isWaiting = true;
        }
    }
}
