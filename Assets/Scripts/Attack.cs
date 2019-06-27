using UnityEngine;
using UnityEditor;
using StateMachineStuff;

public class Attack : State<AI>
{
    private static Attack instance;

    private Attack()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public static Attack Instance
    {
        get
        {
            if (instance == null)
            {
                new Attack();
            }

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entering Attack mode");
        owner.navMeshAgent.Stop();
    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exiting Attack mode");
        owner.navMeshAgent.Resume();

    }

    public override void UpdateState(AI owner)
    {
        Debug.Log("Attacking player!");
        
    }
}