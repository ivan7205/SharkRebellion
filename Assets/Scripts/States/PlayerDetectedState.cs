using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : EnemyBaseState
{
    public PlayerDetectedState(EnemyScript enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        
        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!enemy.CheckForPlayers())
                enemy.SwitchState(enemy.patrolState);
        else
        {
            if (Time.time >= enemy.stateTime + enemy.playerDetectedWaitTime)
                enemy.SwitchState(enemy.chargeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
