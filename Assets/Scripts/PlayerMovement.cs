using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private Transform forcePos;
    [SerializeField] private GameObject wheelchairGraphic;


    public float speed = 5;
    public float rotSpeed = 5;
    public float maxYaw = 5;
    public float maxPitchVel = 3;
    public float jumpforce = 50;
    public float rotationInput;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        rotationInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            wheelchairGraphic.transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal), hit.normal);
            Debug.DrawRay(hit.point, hit.normal);
            Debug.DrawRay(hit.point, Vector3.Cross(transform.right, hit.normal));
        }

        Vector3 forceVector = new Vector2(
            movementInput.x,
            Mathf.Clamp(movementInput.y, -movementInput.y / 5, movementInput.y)
        );

        rb.AddForceAtPosition(
            ((transform.forward * forceVector.y) + (transform.right * forceVector.x)) * speed * Time.fixedDeltaTime,
            forcePos.position,
            ForceMode.Force
        );

        transform.Rotate(new Vector3(
            // Mathf.Clamp(movementInput.x * rotSpeed, -maxYaw, maxYaw),
            0,
            Mathf.Clamp(rotationInput, -maxPitchVel, maxPitchVel),
            0
        ));
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ramp")
        {
            rb.AddForce(transform.up * jumpforce/2 + transform.forward * jumpforce);
        }
    }
}
