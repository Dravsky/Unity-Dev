using TMPro;
using UnityEngine;

public class PlayerTank : MonoBehaviour, I_Damagable
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 1;
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;
    public int ammo = 10;
    [SerializeField] TMP_Text ammoText;

    float torque;
    float force;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            ammo--;
            Instantiate(rocket, barrel.position, barrel.rotation);
        }

        ammoText.text = "Ammo: " + ammo.ToString();
    }

    // Runs at 50 fps, so no need for Delta Time
    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

    public void ApplyDamage(float damage)
    {
        
    }
}