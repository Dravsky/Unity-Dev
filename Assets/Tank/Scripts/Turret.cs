using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform barrel;
    [SerializeField] float rotationSpeed;
    [SerializeField] float detectionRange = 100.0f;
    [SerializeField, Range(0.5f, 5)] float spawnTimeMin;
    [SerializeField, Range(0.5f, 5)] float spawnTimeMax;

    float spawnTime;

    void Start()
    {
        StartCoroutine(SpawnFire());
        //spawnTimer = spawnTime;
    }

    void Update()
    {
        if (enemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= detectionRange)
            {
                Vector3 direction = enemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator SpawnFire()
    {
        while (true)
        {
            spawnTimeMin = Random.Range(0.5f, 1.0f);
            spawnTimeMax = Random.Range(spawnTimeMin, 2.0f);
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(rocketPrefab, barrel.position, barrel.rotation);
        }
    }
}
