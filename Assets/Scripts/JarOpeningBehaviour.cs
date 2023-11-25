using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something has entered the jar");
        if (other.gameObject.CompareTag("fly"))
        {
            Debug.Log("A firefly has entered the jar");
            // Deactivate the firefly
            other.gameObject.SetActive(false);
            Debug.Log("A firefly has been deactivated");
        }
    }
}