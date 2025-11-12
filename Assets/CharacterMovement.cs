using System.Runtime.CompilerServices;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;


    [SerializeField] public InputActionReference move;
    [SerializeField] public InputActionReference jump;


    private float x;
    private float y;
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
        
        Vector2 dir = new Vector2(x * speed, rb.linearVelocityY);
        rb.linearVelocity = dir;

    }
}
