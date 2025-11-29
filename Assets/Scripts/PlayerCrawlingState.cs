using UnityEngine;

public class PlayerCrawlingState : PlayerAbstractState{
    private int turnFrames = 10;
    private int accelFrames = 3;
    private float Speed = 6f;
    private int facing;

    public override void EnterState(PlayerStateManager context) {
        Debug.Log("Hello from the Crawling State");
        context.trans.eulerAngles = Vector3.back * 90 * context.lastX;
        facing = context.lastX;
    }

    public override void doFrame(PlayerStateManager context) {
        if (context.inputY > 0.5f) {
            context.SwitchState(context.walkingState);
        }


        context.rb.linearVelocityX += context.inputX*Speed / accelFrames;
        if (context.inputX == 0) {
            context.rb.linearVelocityX -= Mathf.Sign(context.rb.linearVelocityX) *Speed / accelFrames ;
        }


        context.rb.linearVelocityX = Mathf.Max(-Speed + facing * 2, context.rb.linearVelocityX);
        context.rb.linearVelocityX = Mathf.Min(Speed + facing * 2, context.rb.linearVelocityX);
        
    }
}
