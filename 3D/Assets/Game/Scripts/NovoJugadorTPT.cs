
using UnityEngine;

public class NovoJugadorTPT : MonoBehaviour
{

    //CONTROLADOR DE MOVIMIENTO 
    private CharacterController controller;

    public static float veloMovi = 2f;
    public float veloRota = 10f;

    public float x, z;

    //camara para seguir el personaje 
    [SerializeField]
    private Camera followCamera;

    //Variables para movimiento y validacion del salto 
    private Vector3 veloJugador;
    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;
    public float gravedad = -9.81f;
    public float salto = 1f;

    bool enPiso;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);
        if (enPiso && veloJugador.y < 0)
        {
            veloJugador.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 moveInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(x, 0, z);

        Vector3 moveDirection = moveInput.normalized;

        controller.Move(moveDirection * veloMovi * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            Quaternion rotacion  = Quaternion.LookRotation(moveDirection, Vector3.up );

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, veloRota * Time.deltaTime);
        }
            if(Input.GetButtonDown("Jump") && enPiso)
        {
            veloJugador.y += Mathf.Sqrt(salto * -2.0f * gravedad);
        }

            veloJugador.y += gravedad * Time.deltaTime; 
            controller.Move(veloJugador * Time.deltaTime);
    }
}