using UnityEngine;
using UnityEngine.AI;

public class MOVIMIENTO_ENEMIGO : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public float rangoDeteccion = 10f;

    public Transform[] waypoints;
    public float waypointDistance = 1f;
    private int currentWaypoint = 0; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);  
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        //PLAYER SE ACERCA -> PERSEGUIR 
        if(distancia <= rangoDeteccion)
        {
            agent.SetDestination(player.position);
        }
        //player lejos, patrullar
        else
        {
            if(!agent.pathPending && agent.remainingDistance <= waypointDistance)
            {
                GoToNextWaypoint(); 
            }
        }
    }

    void GoToNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        agent.SetDestination(waypoints[currentWaypoint].position);
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
