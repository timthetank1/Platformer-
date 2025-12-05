using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeadState : PlayerAbstractState
{
    public override void EnterState(PlayerStateManager context)
    {
        Debug.Log("Player has died.");
        context.trans.eulerAngles = Vector3.back * 90;
        context.rb.linearVelocity = Vector2.zero;
    }
    public override void doFrame(PlayerStateManager context)
    {
        if (context.jumpButton)
        {
            Debug.Log("Respawning player...");
            SceneManager.LoadSceneAsync(0);
        }
    }
}
