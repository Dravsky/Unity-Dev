using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RollerController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform view;
    
    Rigidbody rb;
    Vector2 movementInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;
        rb.AddForce(movement * speed);
    }

    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public void OnJump(InputValue inputValue)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}
