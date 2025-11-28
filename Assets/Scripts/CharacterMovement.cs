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
    [SerializeField] private Collision coll;
    private float x;
    private float y;
    private bool jumpButton;
    private Vector2 inputDir;
    private float inputX;
    private float inputY;
    private State state = State.walking;

    enum State{
        idle,
        walking,
        crawling,
        jumping,
        clinging,
        sliding
    }

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    private void Update(){
        playerInput();
    }
    private void playerInput(){
        jumpButton = jump.action.ReadValue<float>() > 0;
        inputDir = move.action.ReadValue<Vector2>();
        inputX = inputDir.x;
        inputY = inputDir.y;
    }


    private void FixedUpdate() {
        Walk();
    }
    private void Walk() {
        rb.linearVelocityX = (rb.linearVelocityX + speed / 3 * inputX)* 0.7f;
        if (jumpButton & coll.onGround)
        {
            Jump(0);
        }
    }
    private void Jump(int side){
        rb.linearVelocityY += jumpForce;
        rb.linearVelocityX += (-side) * jumpForce;
    }





    
}
