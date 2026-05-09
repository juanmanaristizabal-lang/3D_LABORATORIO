using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public float mouseSensitivity = 10f;

    public Transform cuerpoJugador;

    //Para rotar la camara 
    float rotaX = 0f; 

   
    void Start()
    {
        //Bloqueamos la posicion del mouse y lo desaparecemos en la pantalla 
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //capturamos los valores del movimiento del Mouse 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //rotamos nuestra camara en el eje x, se usa el - para evitar lo conocido como "Iverted Axis"
        rotaX -= mouseY;

        //Restriccion de rotacion de la camara entre 90 y -90 grados 
        rotaX = Mathf.Clamp(rotaX, -90f, 90f);

        //Asignamos los valores resultantes de rotacion de la camara al objeto como tal 
        transform.localRotation = Quaternion.Euler(rotaX, 0f, 0f);

        cuerpoJugador.rotation *= Quaternion.Euler(0f, mouseX, 0f);
    }
}
