using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCrawlingState : PlayerAbstractState{
    private int turnFrames = 10;
    private int accelFrames = 3;
    private int turnTimer = 0;
    private float Speed = 8f;
    private float jumpForce = 25;


    private int facing;


    public override void EnterState(PlayerStateManager context) {
        context.trans.eulerAngles = Vector3.back * 90 * context.lastX;
        facing = context.lastX;
        turnTimer = turnFrames;
    }

    public override void doFrame(PlayerStateManager context) {
        switch (facing * context.inputX) {
            case > 0:
                context.rb.linearVelocityX += context.inputX * Speed / accelFrames;
                ClampSpeed(facing * Speed, 4 - facing * Speed, context);
                break;
            case < 0:
                context.rb.linearVelocityX += (context.inputX * Speed - 3) / accelFrames;
                ClampSpeed(facing * Speed, 4 - facing * Speed, context);
                break;
            case 0:
                context.rb.linearVelocityX -= Mathf.Sign(context.rb.linearVelocityX) * 0.5f * Speed /accelFrames;
                ClampSpeed(facing * Speed, 0, context);
                if (Mathf.Abs(context.rb.linearVelocityX) < 0.6f * Speed /accelFrames) {
                    context.rb.linearVelocityX = 0;
                }
                break;
        }
        if (context.inputY > 0.5f) {
            context.SwitchState(context.walkingState);
        }
        if (context.jumpButton) {
            if (turnTimer > 0) {
                context.rb.linearVelocityX = 30f;
                context.SwitchState(context.SlidingState);
            } else {
                context.rb.linearVelocityX *= 1.5f;
                context.rb.linearVelocityY = jumpForce;
                context.SwitchState(context.airborneState);
            }
        }
        turnTimer = Mathf.Max(0, turnTimer - 1);
    }

    private void ClampSpeed(float a, float b, PlayerStateManager context) {
        context.rb.linearVelocityX = Mathf.Min(Mathf.Max(context.rb.linearVelocityX, Mathf.Min(a, b)), Mathf.Max(a, b));
    }
}
