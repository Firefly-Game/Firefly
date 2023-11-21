using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance { get; private set; }
    public List<GameObject> Objects { get; private set; }

    public GameObject objectToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        AddObjectsToPool(1);
    }

    public GameObject InstantiateObject(Vector3 position, Quaternion rotation)
    {
        // Get the first inactive object
        for (int i = 0; i < Objects.Count; i++)
        {
            if (!Objects[i].activeInHierarchy)
            {
                SetupObject(i, position, rotation);
                return Objects[i];
            }
        }

        // If no inactive objects found...
        // Double the pool size
        AddObjectsToPool(Objects.Count);

        SetupObject(Objects.Count / 2, position, rotation);
        return Objects[Objects.Count / 2];
    }

    private void SetupObject(int index, Vector3 position, Quaternion rotation)
    {
        Objects[index].transform.position = position;
        Objects[index].transform.rotation = rotation;
        Objects[index].SetActive(true);
    }

    private void AddObjectsToPool(int amount)
    {
        if (amount <= 0) return;

        if (Objects == null)
        {
            Objects = new List<GameObject>();
        }

        GameObject temporary;
        for (int i = 0; i < amount; i++)
        {
            temporary = Instantiate(objectToPool);
            temporary.SetActive(false);
            Objects.Add(temporary);
        }
    }
}
