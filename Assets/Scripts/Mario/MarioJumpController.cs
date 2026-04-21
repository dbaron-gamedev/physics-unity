using UnityEngine;

public class MarioJumpController : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpVelocity = 12f;     // initial jump force
    public float gravity = -30f;         // constant downward acceleration
    public float maxFallSpeed = -25f;

    [Header("Input")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground")]
    public float groundY = 0f;           // simple ground plane

    private float verticalVelocity = 0f;
    private bool isGrounded = true;

    void Update()
    {
        float dt = Time.deltaTime;

        // -------------------------
        // INPUT (jump start)
        // -------------------------
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            verticalVelocity = jumpVelocity;
            isGrounded = false;
        }

        // -------------------------
        // VARIABLE JUMP HEIGHT
        // (cut upward velocity early if jump released)
        // -------------------------
        if (Input.GetKeyUp(jumpKey) && verticalVelocity > 0)
        {
            verticalVelocity *= 0.5f; // “Mario feel” cut
        }

        // -------------------------
        // APPLY GRAVITY
        // -------------------------
        if (!isGrounded)
        {
            verticalVelocity += gravity * dt;
            verticalVelocity = Mathf.Max(verticalVelocity, maxFallSpeed);
        }

        // -------------------------
        // APPLY MOVEMENT
        // -------------------------
        Vector3 pos = transform.position;
        pos.y += verticalVelocity * dt;

        // -------------------------
        // SIMPLE GROUND COLLISION
        // -------------------------
        if (pos.y <= groundY)
        {
            pos.y = groundY;
            verticalVelocity = 0;
            isGrounded = true;
        }

        transform.position = pos;
    }
}