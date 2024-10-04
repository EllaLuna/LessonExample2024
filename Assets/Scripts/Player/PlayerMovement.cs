using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    Vector2 direction;
    string[] str;
    [SerializeField] Animator animator;
    SpriteRenderer spriteRenderer;
    float jumpForce = 8;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError($"Rigidbody could not be found in script {nameof(PlayerMovement)}");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger(nameof(AnimationParameters.jump));
        }

        direction = new Vector2(Input.GetAxis(nameof(InputStr.Horizontal)), 0);
        animator.SetFloat(nameof(AnimationParameters.moveX), direction.x);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.deltaTime;     
    }

    enum InputStr
    {
        None,
        Horizontal,
        Vertical
    }
    enum AnimationParameters
    {
        moveX,
        jump
    }
}
