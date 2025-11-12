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

public class CharacterMovement : MonoBehaviour
>>>>>>> Stashed changes
{ 
    public Rigidbody2D rb;
    public InputAction controls;
    public float speed = 100;

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
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
 