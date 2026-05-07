using Cinemachine;
using UnityEngine;


public class ChangeCamara : MonoBehaviour
{

    public CinemachineVirtualCamera activeCam;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 10;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created

    }
}