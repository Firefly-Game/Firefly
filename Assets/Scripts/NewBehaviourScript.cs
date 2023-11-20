using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Example : MonoBehaviour
{
    public GameObject target;

    private float time = 0.0f;
    public float directionChangeTime = 30f;
    private Vector3 directionVector;
    private float degrees;

    void Update()
    {
        // Rotate target
        transform.RotateAround(target.transform.position, directionVector, degrees * Time.deltaTime);

        // Increase time 
        time += Time.deltaTime;

        // Change direction if it is time
        if (time >= directionChangeTime)
        {
            time = time - directionChangeTime;
            directionVector = genDirectionVector();
            
        }
    }


    void Start()
    {
        directionVector = genDirectionVector();
        degrees = 45;
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