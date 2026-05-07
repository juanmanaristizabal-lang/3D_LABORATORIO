using UnityEngine;

public class MovimientoQ : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 100f; 

    private Rigidbody rb;
    public Animator anima; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");    
        float verticalInput = Input.GetAxis("Vertical");

        //movimiento 
        Vector3 forwardMovement = transform.forward * verticalInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        //rotacion 
        float rotationAmount = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.AngleAxis(rotationAmount, Vector3.up);
        rb.MoveRotation(rb.rotation * deltaRotation);

        //animacion
        float walkVal = Mathf.Abs(verticalInput);
        anima.SetFloat("Walk", walkVal);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
