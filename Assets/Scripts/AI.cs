using UnityEngine;
using StateMachineStuff;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public StateMachine<AI> StateMachine { get; set; }
    public NavMeshAgent navMeshAgent = null;
    public Transform target;

    private float distance;
    private float rangeOfView = 8f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StateMachine = new StateMachine<AI>(this);
        StateMachine.ChangeState(Patrol.Instance);
        
    }

    private void Update()
    {
        StateMachine.Update();
        target = CheckForAggro();

        if (target != null)
        {
            distance = Vector3.Distance(target.position, this.transform.position);

            if (distance < 2f && StateMachine.CurrentState == Chase.Instance)
            {
                StateMachine.ChangeState(Attack.Instance);
            }
            else if (distance > 2f && StateMachine.CurrentState == Attack.Instance)
            {
                StateMachine.ChangeState(Chase.Instance);
            }
            else if (distance > rangeOfView && StateMachine.CurrentState == Chase.Instance)
            {
                StateMachine.ChangeState(Patrol.Instance);
            }
            else if (distance < rangeOfView && StateMachine.CurrentState == Patrol.Instance)
            {
                StateMachine.ChangeState(Chase.Instance);
            }
        }
        else if(StateMachine.CurrentState == Chase.Instance || StateMachine.CurrentState == Attack.Instance)
        {
            StateMachine.ChangeState(Patrol.Instance);
        }
    }

    Quaternion startingAngle = Quaternion.AngleAxis(-45, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    private Transform CheckForAggro()
    {
        RaycastHit hit;
        Quaternion angle = transform.rotation * startingAngle;
        Vector3 direction = angle * Vector3.forward;
        Vector3 position = transform.position;
        for (var i = 0; i < 18; i++)
        {
            if (Physics.Raycast(position, direction, out hit, rangeOfView))
            {
                var target = hit.collider.GetComponent<Transform>();
                if (target != null )
                {
                    Debug.DrawRay(position, direction * hit.distance, Color.red);
                    return target;
                }
            }
            else
            {
                Debug.DrawRay(position, direction * rangeOfView, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}
