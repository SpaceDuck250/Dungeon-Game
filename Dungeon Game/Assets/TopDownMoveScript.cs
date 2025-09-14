using UnityEngine;

public class TopDownMoveScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float smoothValue;

    public float moveX;
    public float moveY;

    public Vector2 refVelocity;

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    public void Move()
    {
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, new Vector2(moveX, moveY) * speed, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
