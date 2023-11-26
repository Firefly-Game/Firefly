using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireflyBehaviour : MonoBehaviour
{
    public GameObject target;

    private float time = 0.0f;
    private Vector3 directionVector; // Current direction of the firefly
    private Vector3 newDirectionVector; // Direction to change to
    private float degrees; // How many degrees to spin around center per second
    private bool isChangingDirection = false;
    private float startChangeTime; // Last timestamp when a change of direction started
    private float directionChangeTime; // How long a direction change should take

    void Update()
    {
        // Rotate target
        transform.RotateAround(target.transform.position, directionVector, degrees * Time.deltaTime);

        // Increase time 
        time += Time.deltaTime;
        //Debug.Log("Time: " + time);
        //Debug.Log("Direction change time: " + directionChangeTime);

        // Change direction if it is time
        if (time >= directionChangeTime)
        {
            Debug.Log("Changed direction");
            time = 0f;
            newDirectionVector = genDirectionVector();
            Debug.Log("Time to change");
            Debug.Log("Current direction: " + directionVector);
            Debug.Log("New direction: " + newDirectionVector);
            isChangingDirection = true;
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

        float fracComplete = (Time.time - startChangeTime) / directionChangeTime;

        directionVector = Vector3.Slerp(currRelCenter, newRelCenter, fracComplete);
        directionVector += origin;

        //Debug.Log("Fraction complete: " + fracComplete);

        if (fracComplete > 0.99)
        {
            isChangingDirection = false;
            directionVector = newDirectionVector;
            Debug.Log("Completed change");
        }
    }


    void Start()
    {
        directionVector = genDirectionVector();
        newDirectionVector = genDirectionVector();
        degrees = 45;
        directionChangeTime = 2f;
        startChangeTime = Time.time;
        isChangingDirection = true;
        
    }



    Vector3 genDirectionVector()
    {
        Debug.Log("Generated direction");
        int x = Random.Range(0, 4);
        startChangeTime = Time.time;
        switch (x)
        {
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