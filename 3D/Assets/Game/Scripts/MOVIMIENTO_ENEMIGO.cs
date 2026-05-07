using UnityEngine;
using UnityEngine.AI;

public class MOVIMIENTO_ENEMIGO : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public float rangoDeteccion = 10f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        if(distancia <= rangoDeteccion)
        {
            agent.destination = player.position;
        }
        else
        {
            agent.ResetPath();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
