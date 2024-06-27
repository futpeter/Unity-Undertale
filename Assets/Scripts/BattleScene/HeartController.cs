using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private Vector3 startingPos = Vector3.zero;
    private Vector3 movePos;
    private Vector3 targetPos;

    public float speed = 5f;
    public int maxX = 2;
    public int maxY = 2;
    public int minX = -2;
    public int minY = -2;

    private void Start()
    {
        SetHeart();
    }

    public void SetHeart()
    {
        transform.position = startingPos;
        movePos = startingPos;
        targetPos = startingPos;
    }

    private void Update()
    {
        // Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the target position based on input
        targetPos.x = Mathf.Clamp(movePos.x + horizontalInput, minX, maxX);
        targetPos.y = Mathf.Clamp(movePos.y + verticalInput, minY, maxY);

        // Smoothly move towards the target position
        movePos = Vector3.Lerp(movePos, targetPos, speed * Time.deltaTime);

        // Update the position
        transform.position = movePos;
    }
}
