using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sensitivity = 1;
    [SerializeField, Range(2, 10)] float distance;

    InputAction lookAction;
    Vector3 rotation = Vector3.zero; //x = pitch, y = yaw, z = roll

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        lookAction.performed += Look;
        //lookAction.canceled += Look;
    }

    void Update()
    {
        Quaternion qrotation = Quaternion.Euler(rotation);
        transform.position = target.position + qrotation * (Vector3.back * distance);
        transform.rotation = qrotation;
    }

    void Look(InputAction.CallbackContext ctx)
    {
        var look = ctx.ReadValue<Vector2>();

        rotation.x += look.y * sensitivity;
        rotation.y += look.x * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, 20, 80);
    }
}