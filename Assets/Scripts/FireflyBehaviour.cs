using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireflyBehaviour : MonoBehaviour
{
    public GameObject target;

    private float time = 0.0f;
    public float journeyTime;
    private Vector3 directionVector;
    private Vector3 newDirectionVector;
    private float degrees;
    private bool isChangingDirection = false;

    void Update()
    {
        // Rotate target
        transform.RotateAround(target.transform.position, directionVector, degrees * Time.deltaTime);

        // Increase time 
        time += Time.deltaTime;
        Debug.Log("Time: " + time);
        Debug.Log("Direction change time: " + journeyTime);

        // Change direction if it is time
        if (time >= journeyTime)
        {
            Debug.Log("Changed direction");
            time = 0f;
            directionVector = genDirectionVector();
            
        }

        if (isChangingDirection )
        {
            updateDirection();
        }
    }

    void updateDirection() {

        Vector3 center = (newDirectionVector + directionVector) * 0.5f;
        
        Vector3 currRelCenter = directionVector - center;
        Vector3 newRelCenter = newDirectionVector - center;

        float fracComplete = (Time.deltaTime - time) / journeyTime;

        directionVector = Vector3.Slerp(currRelCenter, newRelCenter, fracComplete);
        directionVector += center;

        if (fracComplete > 0.99)
        {
            isChangingDirection = false;
        }
    }


    void Start()
    {
        directionVector = genDirectionVector();
        newDirectionVector = genDirectionVector();
        degrees = 45;
        journeyTime = 1f;
        isChangingDirection = true;
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