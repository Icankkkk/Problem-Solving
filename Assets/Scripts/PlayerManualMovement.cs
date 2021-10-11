using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManualMovement : MonoBehaviour
{
    // header
    [Header("Ball Movement")]
    public float speed = 6f;  // speed for ball

    Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // panggil method Move
        Move(h, v);
    }

    /* method untuk menggerakan ball
     * A = left
     * W = up
     * S = down
     * D = right
     * 
     * atau bisa menggunakan arrow
     */
    public void Move(float h, float v)
    {
        Vector3 temVect = new Vector3(h, v, 0);
        temVect = temVect.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.transform.position + temVect);
    }

}
