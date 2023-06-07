using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forwardSpeed = 3;
    public float lateralSpeed = 4;
    public float laneWidth = 2;
    public int currentLane = 1;
    private bool isMoving = false;

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);

        // Check if the player is currently moving
        if (!isMoving)
        {
            // Move left
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            {
                StartCoroutine(MoveToLane(currentLane - 1));
            }

            // Move right
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            {
                StartCoroutine(MoveToLane(currentLane + 1));
            }
        }
    }

    IEnumerator MoveToLane(int targetLane)
    {
        isMoving = true;

        float targetX = (targetLane - 1) * laneWidth;
        float elapsedTime = 0;
        float startX = transform.position.x;

        while (elapsedTime < 0.25f)
        {
            float t = elapsedTime / 0.25f;
            float newX = Mathf.Lerp(startX, targetX, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        currentLane = targetLane;
        isMoving = false;
    }
}


