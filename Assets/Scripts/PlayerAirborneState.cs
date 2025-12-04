using UnityEngine;

public class PlayerAirborneState : PlayerAbstractState {
    private int facing;
    public override void EnterState(PlayerStateManager context) {
        facing = (Mathf.Abs(context.rb.linearVelocityX) > 10) ? (int)Mathf.Sign(context.inputX) : 0 ;
    }

    public override void doFrame(PlayerStateManager context)
    {
        if (context.coll.onGround())
        {
            context.SwitchState(context.walkingState);
        }
        switch (facing * context.inputX)
        {
            case > 0:
                context.rb.linearVelocityX -= facing * 0.2f;
                break;
            case < 0:
                context.rb.linearVelocityX -= facing;
                break;
            case 0:
                context.rb.linearVelocityX += context.inputX * 3;
                break;
        }
    }
}
