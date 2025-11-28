using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private LayerMask collisionLayer;
    
    public bool onGround;
    public bool onWall;
    private bool onRightWall;
    private bool onLeftWall;
    public int wallSide = 0;


    [Header("Collision Parameters")]
    
    [SerializeField] private float collisionRadius = 0.4f;
    [SerializeField] private Vector2 bottomOffset = Vector2.down  * 0.2f;
    [SerializeField] private Vector2 rightOffset  = Vector2.right * 0.2f;
    [SerializeField] private Vector2 leftOffset   = Vector2.left  * 0.2f;



    private void Update(){
        onGround    = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, collisionLayer);
        onLeftWall  = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset,   collisionRadius, collisionLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset,  collisionRadius, collisionLayer);
        onWall      = onLeftWall || onRightWall;
        wallSide    = (onRightWall? 1 : 0) - (onLeftWall? 1 : 0);

    }
}
