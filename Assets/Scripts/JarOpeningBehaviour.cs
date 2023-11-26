using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JarBehaviour : MonoBehaviour
{
    public ScoreLabel scoring;
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
        if (other.gameObject.CompareTag("fly"))
        {
            Debug.Log("A firefly has entered the jar");
            // Deactivate the firefly
            other.gameObject.SetActive(false);
            Debug.Log("A firefly has been deactivated");
            scoring.OnCatch();

        }
    }
}