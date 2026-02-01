using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolState : EnemyBaseState
{
    public PatrolState(EnemyScript enemy, string animationName) : base(enemy, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.CheckForPlayers())
            enemy.SwitchState(enemy.playerDetectedState);

        if (enemy.CheckForLegde())
            Rotate();
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (enemy.facingRight)
            enemy.rb.velocity = new Vector2(-enemy.speed, enemy.rb.velocity.y);
        else
            enemy.rb.velocity = new Vector2(enemy.speed, enemy.rb.velocity.y);
    }


    void Rotate()
    {
        enemy.transform.Rotate(0, 180, 0);
        enemy.facingRight = !enemy.facingRight;

    }
}
