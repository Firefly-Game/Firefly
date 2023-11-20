using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Example : MonoBehaviour
{
    public GameObject target;

    private float time = 0.0f;
    public float directionChangeTime;
    private Vector3 directionVector;
    private float degrees;

    void Update()
    {
        // Rotate target
        transform.RotateAround(target.transform.position, directionVector, degrees * Time.deltaTime);

        // Increase time 
        time += Time.deltaTime;
        Debug.Log("Time: " + time);
        Debug.Log("Direction change time: " + directionChangeTime);

        // Change direction if it is time
        if (time >= directionChangeTime)
        {
            Debug.Log("Changed direction");
            time = 0f;
            directionVector = genDirectionVector();
            
        }
    }


    void Start()
    {
        directionVector = genDirectionVector();
        degrees = 45;
        directionChangeTime = 1f;
    }

    

    Vector3 genDirectionVector() {
        
        int x = Random.Range(0, 4);
        switch (x) { 
            case 0:
                return -Vector3.forward;
            case 1:
                return Vector3.forward;
            case 2:
                return Vector3.up;
            default:
                return Vector3.down;
        }
    
    }
}