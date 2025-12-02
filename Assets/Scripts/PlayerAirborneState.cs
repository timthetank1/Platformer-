using UnityEngine;

public class PlayerAirborneState : PlayerAbstractState {
    private int facing;
    public override void EnterState(PlayerStateManager context) {
        Debug.Log("Player has entered Airborne state");
        facing = (int)Mathf.Sign(context.rb.linearVelocityX);
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
            case 0: break;
        }
    }
}
