using UnityEngine;

public class KeyMover : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 0.02f;
    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
                shouldMove = false; 
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}