using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Collision : MonoBehaviour {
   private Collider2D _collider;
    [Header("Collision Parameters")]
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private LayerMask hazardLayer;
    [SerializeField] private float collisionRadius = 0.4f;
    [SerializeField] private Vector2 bottomOffset = Vector2.down * 0.2f;
    [SerializeField] private Vector2 rightOffset = Vector2.right * 0.2f;
    [SerializeField] private Vector2 leftOffset = Vector2.left * 0.2f;
    [SerializeField] private bool _active = true;
    private bool CheckCollision(Vector2 offset){
       return Physics2D.OverlapCircle((Vector2)transform.position + offset, collisionRadius, collisionLayer);
    }

    public bool onGround(){
        return CheckCollision(bottomOffset);
    }

    private bool onLeftWall(){
        return CheckCollision(leftOffset);
    }

    private bool onRightWall(){
        return CheckCollision(rightOffset);
    }

    public bool onWall(){
        return onRightWall() || onLeftWall();
    }

    public int wallSide(){
        return (onRightWall()? 1 : 0) - (onLeftWall()? 1 : 0);
    }


}
