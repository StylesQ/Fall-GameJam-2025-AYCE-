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
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, LayerMask.NameToLayer("Ground")))
        {
            Debug.DrawRay(hit.point, hit.normal);
        }
        
        Vector3 forceVector = new Vector2(
            movementInput.x,
            Mathf.Clamp(movementInput.y, -movementInput.y/5, movementInput.y)
        );

        rb.AddForceAtPosition(
            ((transform.forward * forceVector.y) + (transform.right * forceVector.x)) * speed * Time.fixedDeltaTime,
            forcePos.position,
            ForceMode.Force
        );

        rb.angularVelocity = new Vector3(
            Mathf.Clamp(rb.angularVelocity.x, -maxPitchVel, maxPitchVel),
            Mathf.Clamp(movementInput.x * rotSpeed, -maxYaw, maxYaw),
            0
        );
    }
}
