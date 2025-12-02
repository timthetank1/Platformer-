using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerWalkingState : PlayerAbstractState {
    private int turnFrames = 10;
    private int accelFrames = 5;
    private float Speed = 20f;
    private float jumpForce = 25;

    private int facing;

    public override void EnterState(PlayerStateManager context) {
        Debug.Log("Player has entered the Walking State.");
        context.trans.eulerAngles = Vector3.zero;
    }

    public override void doFrame(PlayerStateManager context) {
        if (context.inputY < -0.5) {
            context.SwitchState(context.crawlingState);
        }

        switch (facing * context.inputX) {
            case > 0:
                context.rb.linearVelocityX += context.inputX * Speed / accelFrames;
                ClampSpeed(Speed, -Speed, context);
                break;
            case < 0:
                context.rb.linearVelocityX += context.inputX * Speed / accelFrames;
                ClampSpeed(-facing * Speed, 0, context);
                break; 
            case 0:
                context.rb.linearVelocityX -= Mathf.Sign(context.rb.linearVelocityX) * 0.5f * Speed / accelFrames;
                if (Mathf.Abs(context.rb.linearVelocityX) < 0.6 * Speed / accelFrames) {
                    context.rb.linearVelocityX = 0;
                }
                ClampSpeed(Speed,-Speed, context);
                break;
        }
        facing = (int)Mathf.Sign(context.inputX);
        if (context.jumpButton)
        {
            context.rb.linearVelocityX *= 1.5f;
            context.rb.linearVelocityY = jumpForce;
            context.SwitchState(context.airborneState);
        }
    }
    
    private void ClampSpeed(float a, float b, PlayerStateManager context) {
        context.rb.linearVelocityX = Mathf.Min(Mathf.Max(context.rb.linearVelocityX, Mathf.Min(a, b)), Mathf.Max(a, b));
    }
}
