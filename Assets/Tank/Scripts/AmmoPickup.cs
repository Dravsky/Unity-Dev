using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] int ammoCount = 5;
    [SerializeField] float rotation = 0;
    [SerializeField] GameObject pickupFx;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerTank component))
            {
                component.ammo += ammoCount;
                Destroy(gameObject);
                if (pickupFx != null)
                {
                    Instantiate(pickupFx, transform.position, Quaternion.identity);
                }
            }
        }
    }
}