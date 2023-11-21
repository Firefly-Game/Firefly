using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireflyBehaviour : MonoBehaviour
{
    public GameObject target;

    private float time = 0.0f;
    public float directionChangeTime;
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
        Debug.Log("Direction change time: " + directionChangeTime);

        // Change direction if it is time
        if (time >= directionChangeTime)
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

    // Referenced from unity documentation https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html
    void updateDirection() {

        Vector3 origin = (newDirectionVector + directionVector) * 0.5f;
        
        Vector3 currRelCenter = directionVector - origin;
        Vector3 newRelCenter = newDirectionVector - origin;

        float fracComplete = (Time.deltaTime - time) / directionChangeTime;

        directionVector = Vector3.Slerp(currRelCenter, newRelCenter, fracComplete);
        directionVector += origin;

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
        directionChangeTime = 1f;
        isChangingDirection = true;
    }

    

    Vector3 genDirectionVector() {
        
        int x = Random.Range(0, 2);
        switch (x) { 
            case 0:
                return Quaternion.Euler(0, -45, 0) * directionVector;
            default:
                return Quaternion.Euler(0, 45, 0) * directionVector;
            
        }
    
    }
}