using UnityEngine;

public class SmoothMovementX : MonoBehaviour
{
    public float moveDistance = 5f; // Расстояние для движения
    public float moveSpeed = 2f; // Скорость движения

    private float startPosX;
    private float endPosX;
    private bool movingForward = true;

    void Start()
    {
        startPosX = transform.position.x;
        endPosX = startPosX + moveDistance;
    }

    void Update()
    {
        if (movingForward)
        {
            MoveObject(startPosX, endPosX);
        }
        else
        {
            MoveObject(endPosX, startPosX);
        }
    }

    void MoveObject(float startPos, float endPos)
    {
        float step = moveSpeed * Time.deltaTime;
        float newX = Mathf.MoveTowards(transform.position.x, endPos, step);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (transform.position.x == endPos)
        {
            movingForward = !movingForward;
        }
    }
}
