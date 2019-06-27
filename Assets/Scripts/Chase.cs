using UnityEngine;
using UnityEditor;
using StateMachineStuff;

public class Chase : State<AI>
{
    private static Chase instance;

    private Chase()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public static Chase Instance
    {
        get
        {
            if (instance == null)
            {
                new Chase();
            }

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entering Chase mode");
        owner.navMeshAgent.SetDestination(owner.target.position);

    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exiting Chase mode");

    }

    public override void UpdateState(AI owner)
    {
        if (owner.navMeshAgent != null)
        {
                owner.navMeshAgent.SetDestination(owner.target.position);
        }
    }
}