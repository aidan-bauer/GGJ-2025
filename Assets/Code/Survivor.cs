using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Survivor : MonoBehaviour
{

    NavMeshPath path;

    public Transform goal;
    NavMeshAgent agent;

    [SerializeField] GameEvent onDeath;
    [SerializeField] int health = 50;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        path = new NavMeshPath();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetermineDestination()
    {
        NavMeshHit hit;

        agent.CalculatePath(goal.position, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(goal.position);
        } else
        {
            if (NavMesh.SamplePosition(transform.position, out hit, 10f, 1 << NavMesh.GetAreaFromName("Safety")))
            {
                agent.SetDestination(hit.position);
            }
        }
    }
}
