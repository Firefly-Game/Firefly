using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class CollisionDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Firefly")) // Make sure your object has this tag
            {
                other.gameObject.SetActive(false); // This disables the object
            }
        }
    }
}
