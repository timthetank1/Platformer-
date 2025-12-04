using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class PlayerStateManager : MonoBehaviour {
    [SerializeField] public Collision coll;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform trans;

    [SerializeField] public InputActionReference move;
    [SerializeField] public InputActionReference jump;

    public bool jumpButton  { get; private set; }
    public Vector2 inputDir { get; private set; }
    public float inputX     { get; private set; }
    public float inputY     { get; private set; }
    public int lastX        { get; private set; }

    public PlayerAbstractState currentState;
    public PlayerWalkingState walkingState = new PlayerWalkingState();
    public PlayerCrawlingState crawlingState = new PlayerCrawlingState();
    public PlayerAirborneState airborneState = new PlayerAirborneState();
    public PlayerSlidingState SlidingState = new PlayerSlidingState();
    public PlayerDeadState deadState = new PlayerDeadState();



    private void Start() {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

        currentState = airborneState;
        currentState.EnterState(this);

        lastX = 1;
    }

    private void FixedUpdate() {
        playerInput();
        currentState.doFrame(this);
    }


    private void playerInput(){
        jumpButton = jump.action.ReadValue<float>() > 0;
        inputDir = move.action.ReadValue<Vector2>();
        inputX = inputDir.x;
        inputY = inputDir.y;
        if (inputX < 0){
            lastX = -1;
        } else if (inputX > 0){
            lastX = 1;
        }
    }
    public void SwitchState(PlayerAbstractState state){
        currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard Layer")) {
            SwitchState(deadState);
        }
    }
}
