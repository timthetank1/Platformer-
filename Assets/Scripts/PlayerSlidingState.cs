using UnityEngine;

public class PlayerSlidingState : PlayerAbstractState {
    private int slideFrames = 20;
    private int slideTimer;

    public override void EnterState(PlayerStateManager context) {
        context.trans.eulerAngles = Vector3.back * 90 * context.lastX;
        slideTimer = slideFrames;
    }

    public override void doFrame(PlayerStateManager context) {
        if (context.jumpButton) { 
            context.rb.linearVelocityX = 40f;
            context.SwitchState(context.airborneState);
        }
        if (slideTimer <= 0) {
            context.SwitchState(context.walkingState);
        }
    }
}
