using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public JumpMovement jumpScript;
    public Rigidbody2D rb2D;
    public Transform transform1;
    public float xVelocitySpeed, maxJumpHeight=5f;
    float movementInputX, currentPosi;

    /// <summary>
    /// With Update Function the Frames are better optimized for Exampel: Controls.
    /// The Function Checks every frame if we pressed something.
    /// The better your pc, the better the control.
    /// </summary>
    private void Update()
    {
        // Input.GetAxisRaw("Horizontal") = Output is 1 if you press D or right ArrowKey
        // Input.GetAxisRaw("Horizontal") = Output is -1 if you press A or left ArrowKey
        movementInputX = Input.GetAxisRaw("Horizontal");
        if (transform1.position.y > currentPosi+maxJumpHeight)
        {
            jumpScript.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentPosi = transform1.position.y;
        // IF the collision tag is being detected as "Ground" the jumpin script is enabled
        if (collision.collider.tag == "Ground")
        {
            jumpScript.enabled = true;
        }
    }

    // With FixedUpdate frames are better caculated and we are messing with Physic
    private void FixedUpdate()
    {
        // All that above times movementX so it can move right or left. Example: speed = 100 * movementInputX = -1
        // 100 * -1 = -100 wihch means its going left
        Vector3 movement = new Vector3(movementInputX, 0, 0);
        transform.position += movement * Time.deltaTime * xVelocitySpeed;
      
        // If a Horizontal Key is pressed E.g:A, then rotate the charakter about 180 degree
        if (movementInputX == -1)
        {
            transform1.localRotation = Quaternion.Euler(0, 180, 0);
        }
        // If a Horizontal Key is pressed E.g:D, then rotate the charakter about 0 degree
        else if (movementInputX == 1)
        {
            transform1.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

   
}