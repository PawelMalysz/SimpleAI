using UnityEngine;
using UnityEditor;
using StateMachineStuff;

public class Patrol : State<AI>
{
    private static Patrol instance;

    private Patrol()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    public static Patrol Instance
    {
        get
        {
            if(instance == null)
            {
                new Patrol();
            }

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entering Patrol mode");
    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exiting Patrol mode");
        
    }

    public override void UpdateState(AI owner)
    {
        GoToRandomPoint(owner);
    }

    public void GoToRandomPoint(AI owner)
    {
        if (owner.navMeshAgent == null)
        {
            Debug.LogError("Can't find NavMeshAgent");
        }
        else
        {
            if ((owner.navMeshAgent.remainingDistance < 0.5f || !owner.navMeshAgent.hasPath) && owner.target == null)
            {
                owner.navMeshAgent.SetDestination(RandomVector3());
            }
        }
    }

    private Vector3 RandomVector3()
    {
        System.Random rnd = new System.Random();
        Vector3 vector = new Vector3(rnd.Next(-20, 20), 1, rnd.Next(-20, 20));
        //Debug.Log("Wylosowano: " + vector.ToString());

        return vector;
    }
}