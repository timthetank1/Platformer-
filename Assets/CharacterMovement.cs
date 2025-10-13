using Unity.Hierarchy;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    void Start()
    {
        RigidBody = GetComponent <RigidBody>();
    }
    void FixedUpdate()
    {
        RigidBody.AddForce(new Vector2(10f, 0f));
    }
}
 