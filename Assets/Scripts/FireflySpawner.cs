using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireflySpawner : MonoBehaviour
{
    public GameObject firefly;
    public GameObject moth;
    public static readonly float spawnRadius = 2.5f;

    // The amount of different objects we want to spawn
    private Dictionary<GameObject, int> amountToSpawn;

    void Start()
        // Instatiate dictionary
    {
        amountToSpawn = new()
    {
        { firefly,    95 },
        { moth,      5 },
    };


        // Spawn the amount of each gameobject
        foreach (KeyValuePair<GameObject, int> kvp in amountToSpawn)
        {
            Debug.Log("Object to spawn: " + kvp.Key);
            Debug.Log("Amount: " + kvp.Value);
            for (int i = 0; i < kvp.Value; i++)
            {
                Spawn(kvp.Key);
            }
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
            Spawn(firefly); // Spawn fireflies only
        }
    }

    void Spawn(GameObject gameObject)
    {
        ObjectPool.SharedInstance.InstantiateObject(
            GetPositionOnSphere(),
            transform.rotation, gameObject
            );
    }

    

    public Vector3 GetPositionOnSphere()
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
