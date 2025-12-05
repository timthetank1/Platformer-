using UnityEngine;

public class PlayerSlidingState : PlayerAbstractState {
    private int slideFrames = 25;
    private int slideTimer;
    private int facing;

    public override void EnterState(PlayerStateManager context) {
        context.trans.eulerAngles = Vector3.back * 90 * context.lastX;
        slideTimer = slideFrames;

    }

    public override void doFrame(PlayerStateManager context) {
        if (context.jumpButton) { 
            context.rb.linearVelocityX = 70f;
            context.rb.linearVelocityY = 50f;
            context.SwitchState(context.airborneState);
        }
        if (slideTimer <= 0) {
            context.SwitchState(context.walkingState);
        }
        if (! context.coll.onGround()) {
            context.SwitchState(context.airborneState);
        }
        slideTimer -= 1;
    }
}
