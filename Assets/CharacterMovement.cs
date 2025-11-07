using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float jumpForce = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        rb.linearVelocity = dir * speed;
        ;

    }
}
