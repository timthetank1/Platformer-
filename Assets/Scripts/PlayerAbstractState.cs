using UnityEngine;

public abstract class PlayerAbstractState
{
    abstract public void EnterState(PlayerStateManager context);
    abstract public void doFrame(PlayerStateManager context);
}
