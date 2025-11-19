using Unity.Hierarchy;
using UnityEngine;
<<<<<<< Updated upstream
<<<<<<< Updated upstream

public class CharacterMovement : MonoBehaviour
{
    Rigidbody RigidBody;
    void Start()
=======
using UnityEngine.InputSystem;
using System;

public class CharacterMovement : MonoBehaviour
=======
using UnityEngine.InputSystem;
using System;

<<<<<<< Updated upstream
public class CharacterMovement : MonoBehaviour
>>>>>>> Stashed changes
{ 
    public Rigidbody2D rb;
    public InputAction controls;
    public float speed = 100;
=======
    [SerializeField] public InputActionReference move;
    [SerializeField] public InputActionReference jump;


    private float x;
    private float y;
    private Vector2 InputDir;
    private Vector2 dir;
    private float JumpDir;  
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    private void Start()
>>>>>>> Stashed changes
    {
        RigidBody = GetComponent <RigidBody>();
    }
    void FixedUpdate()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        RigidBody.AddForce(new Vector2(10f, 0f));
=======
=======
>>>>>>> Stashed changes
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        rb.linearVelocity = dir * speed;
    }
    private void FixedUpdate()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        if
            jumpForce = 0
        else

                    
        InputDir = move.action.ReadValue<Vector2>();
        x = InputDir[0];
<<<<<<< Updated upstream
=======

        JumpDir = jump.action.ReadValue<float>();
        y = JumpDir * jumpForce;

        Vector2 dir = new Vector2(x * speed, rb.linearVelocityY + y);
        rb.linearVelocity = dir;
>>>>>>> Stashed changes

        JumpDir = jump.action.ReadValue<float>();
        y = JumpDir * jumpForce;

        Vector2 dir = new Vector2(x * speed, rb.linearVelocityY + y);
        rb.linearVelocity = dir;
>>>>>>> Stashed changes

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
 