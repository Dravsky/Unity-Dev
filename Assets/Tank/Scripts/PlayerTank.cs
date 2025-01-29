using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    [SerializeField] float maxTorque = 90;
    [SerializeField] float maxForce = 1;
    [SerializeField] Transform barrel;
    [SerializeField] GameObject rocket;
    public int ammo = 10;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Slider healthSlider;
    [SerializeField] public bool powerUp = false;
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip music;
    bool everyOther = false;

    float torque;
    float force;

    Rigidbody rb;
    PlayerDestructable destructable;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<PlayerDestructable>();

        if (audioSource != null && music != null)
        {
            audioSource.PlayOneShot(music);
        }
    }

    void Update()
    {

        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetButtonDown("Fire1") && ammo > 0 && !powerUp)
        {
            ammo--;
            Instantiate(rocket, barrel.position, barrel.rotation);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 euler = transform.eulerAngles;

            euler.x = 0f;
            euler.z = 0f;

            transform.rotation = Quaternion.Euler(euler);

            destructable.Health -= 2;

            if (audioSource != null && hurt != null)
            {
                audioSource.PlayOneShot(hurt);
            }
        }

        ammoText.text = "Ammo: " + ammo.ToString();
        if (powerUp) ammoText.text = "Ammo: Infinite";

        healthSlider.value = destructable.Health;
        if (destructable.Health <= 0)
        {
            ammo = 0;
            transform.position = new Vector3 (0, 10, -100);
            GameManager.Instance.SetGameOver();
        }
    }

    // Runs at 50 fps, so no need for Delta Time
    private void FixedUpdate()
    {
        everyOther = !everyOther;
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);

        if (Input.GetButton("Fire1") && powerUp && everyOther)
        {
            Instantiate(rocket, barrel.position, barrel.rotation);
        }
    }
}