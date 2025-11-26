using System.Runtime.CompilerServices;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    private bool groundTouch = false;

    [SerializeField] public InputActionReference move;
    [SerializeField] public InputActionReference jump;


    private float x;
    private float y;
    private float JumpDir;
    private Vector2 InputDir;
    private Vector2 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    


    private void FixedUpdate()
    {
        InputDir = move.action.ReadValue<Vector2>();
        x = InputDir[0];
        JumpDir = jump.action.ReadValue<float>();
        if (groundTouch & (jump.action.ReadValue<float>()== 1))
        {
            y = jumpForce;
        }
        else 
        {
            y = 0; 
        }

        Debug.Log(groundTouch);
        Vector2 dir = new Vector2(x * speed, rb.linearVelocityY + y);
        rb.linearVelocity = dir;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundTouch = true;
        }
        else
        {
            groundTouch = false;
        }
    }

}
