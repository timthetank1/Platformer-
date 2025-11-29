using UnityEngine;

public class PlayerWalkingState : PlayerAbstractState {
    private int turnFrames = 10;
    private float Speed = 20f;

    public override void EnterState(PlayerStateManager context) {
        Debug.Log("Player has entered the Walking State.");
        context.trans.eulerAngles = Vector3.zero;
    }

    public override void doFrame(PlayerStateManager context) {
        if (context.inputY < -0.5) {
            context.SwitchState(context.crawlingState);
        }
    }
}
