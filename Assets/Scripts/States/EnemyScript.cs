using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public EnemyBaseState currentState;

    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public ChargeState chargeState;

    public Rigidbody2D rb;
    public Transform LedgeDetector;
    public LayerMask groundLayer, playerLayer;

    public bool facingRight = true;
    
    public float raycastDistance, playerDetectDistance;
    public float speed;
    public float DetectionPauseTime;
    public float stateTime;
    public float playerDetectedWaitTime = 1F;
    public float chargeTime;
    public float chargeSpeed;

    private bool playerDetected;
    

    
    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        chargeState = new ChargeState(this, "charge");

        currentState = patrolState;
        currentState.Enter();
    }



    private void Update()
    {
        currentState.LogicUpdate();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.PhysicsUpdate();
        
        if (!playerDetected) {

            
        }     
            
        
    }



    public bool CheckForLegde()
    {
        RaycastHit2D hit = Physics2D.Raycast(LedgeDetector.position, Vector2.down, raycastDistance, groundLayer);

        if (hit.collider == null)
        {
            return true;
            
        } else {
            return false;
        }

    }

    public bool CheckForPlayers()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(LedgeDetector.position, facingRight? Vector2.right : Vector2.left, playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
            return true;
        else 
            return false;
        


    }



  


    public void SwitchState(EnemyBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(LedgeDetector.position, (facingRight ? Vector2.right : Vector2.left) * playerDetectDistance);
    }
}
