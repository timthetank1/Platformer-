using System.Runtime.CompilerServices;
using Unity.Hierarchy;
using Unity.VisualScripting;
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
}
