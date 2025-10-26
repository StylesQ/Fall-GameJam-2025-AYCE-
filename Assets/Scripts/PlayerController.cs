using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpForce = 20;
    [SerializeField] float _rotationSpeed = 20;
    Vector2 _moveDir;
    Rigidbody _rb;

   

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        PlayerInputHandler.MoveInput += OnMoveInput;
        PlayerInputHandler.JumpInput += OnJumpInput;

    }

    private void OnDisable()
    {
        PlayerInputHandler.MoveInput -= OnMoveInput;
        PlayerInputHandler.JumpInput -= OnJumpInput;
    }

    void OnMoveInput(Vector2 moveDir)
    {
        _moveDir = moveDir;
    }

    private void Update()
    {
        // Movement
        var move = new Vector3(_moveDir.x, 0, _moveDir.y);
        move = Camera.main.transform.forward * move.z + Camera.main.transform.right * move.x;
        move.y = 0f;

        _rb.AddForce(move * Time.deltaTime * _moveSpeed);


        // Try rotate only if input is not nothing
        if (move == Vector3.zero) return;

        // Rotate Character
        Quaternion rotateTo = Quaternion.LookRotation(move, Vector3.up);
        _rb.rotation = Quaternion.Slerp(_rb.rotation, rotateTo, _rotationSpeed * Time.deltaTime);
        
    }

    void OnJumpInput()
    {
        if (!isGrounded()) return;

        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }


    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
    }
}
