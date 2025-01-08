using UnityEditor.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1, 10), Tooltip("Change the speed")] public float speed = 2.0f;
    public GameObject predfab;

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        transform.position += velocity * Time.deltaTime * speed;

        // Create prefab
        while (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(predfab, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}
