using System.Collections;
using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    const int initialNumber = 100;
    public static readonly float spawnRadius = 2.5f;

    void Start()
    {
        for (int i = 0; i < initialNumber; i++)
        {
            Spawn();
        }

        StartCoroutine(TimedSpawn());
    }

    void Update()
    {

    }

    IEnumerator TimedSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Spawn();
        }
    }

    void Spawn()
    {
        ObjectPool.SharedInstance.InstantiateObject(
            GetPositionOnSphere(spawnRadius),
            transform.rotation
            );
    }

    Vector3 GetPositionOnSphere(float radius)
    {
        float x = 0, y = 0, z = 0;
        while (x == 0 & y == 0 & z == 0)
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            z = Random.Range(-1f, 1f);
        }

        float normalizer = 1 / Mathf.Sqrt(x * x + y * y + z * z);

        x *= normalizer;
        y *= normalizer;
        z *= normalizer;

        return new Vector3(x, y, z) * spawnRadius;
    }
}
