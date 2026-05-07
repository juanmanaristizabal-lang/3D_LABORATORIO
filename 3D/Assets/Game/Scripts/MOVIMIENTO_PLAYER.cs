using UnityEngine;
using UnityEngine.AI;

public class MOVIMIENTO_PLAYER : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public Animator anima;



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anima = GetComponent<Animator>();
    }

   

}
