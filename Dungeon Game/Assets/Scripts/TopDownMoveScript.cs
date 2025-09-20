using UnityEngine;

public class TopDownMoveScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float smoothValue;

    public float moveX;
    public float moveY;

    public Vector3 startScale;

    public Vector2 refVelocity;

    public Animator animator;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("speed", rb.linearVelocity.magnitude);
    }

    public void Move()
    {
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, new Vector2(moveX, moveY) * speed, ref refVelocity, smoothValue * Time.fixedDeltaTime);
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Flip()
    {
        if (moveX > 0)
        {
            transform.localScale = new Vector3(startScale.x * -1, startScale.y, 0);
        }
        else if (moveX < 0)
        {
            transform.localScale = startScale;
        }
        
    }
}
