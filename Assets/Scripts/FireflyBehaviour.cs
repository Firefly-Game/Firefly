using System.Collections.Generic;
using UnityEngine;

public class FireflyBehaviour : MonoBehaviour
{
    public GameObject target;
    public ScoreLabel scoreLabel;

    private float time = 0.0f;
    private Vector3 directionVector; // Current direction of the firefly
    private Vector3 newDirectionVector; // Direction to change to
    private float degrees; // How many degrees to spin around center per second
    private bool isChangingDirection = false;
    private float startChangeTime; // Last timestamp when a change of direction started
    private float directionChangeTime; // How long a direction change should take

    public FireflyType Type { get; protected set; } = FireflyType.Common;

    private Dictionary<FireflyType, int> typeDistribution = new Dictionary<FireflyType, int>
    {
        { FireflyType.Common,    100 },
        { FireflyType.Rare,      25 },
        { FireflyType.Epic,      5 },
        { FireflyType.Legendary, 1 },

    };

    private Dictionary<FireflyType, Color> typeColors = new Dictionary<FireflyType, Color>
    {
        { FireflyType.Common,    new Color(1f, 1f, 1f, 1f) },
        { FireflyType.Rare,      new Color(0.12f, 0.64f, 1f) },
        { FireflyType.Epic,      new Color(0.48f, 0.32f, 0.89f) },
        { FireflyType.Legendary, new Color(0.95f, 0.77f, 0.06f) },
        { FireflyType.Moth,      new Color(0f, 1f, 0f, 1f) },
    };

    public enum FireflyType
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Moth
    }

    void Start()
    {
        InitValues();
        SetType();
        SetColor();
    }

    protected void InitValues()
    {
        directionVector = genDirectionVector();
        newDirectionVector = genDirectionVector();
        degrees = 45;
        directionChangeTime = 2f;
        startChangeTime = Time.time;
        isChangingDirection = true;
    }

    private void SetType()
    {
        int total = 0;
        foreach (var item in typeDistribution)
        {
            total += item.Value;
        }

        int random = (int)(Random.value * total);
        int current = 0;
        foreach (var item in typeDistribution)
        {
            current += item.Value;
            if (current > random)
            {
                Type = item.Key;
                break;
            }
        }
    }

    protected void SetColor()
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", typeColors[Type]);
    }

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
            //Debug.Log("Changed direction");
            time = 0f;
            newDirectionVector = genDirectionVector();
            //Debug.Log("Time to change");
            //Debug.Log("Current direction: " + directionVector);
            //Debug.Log("New direction: " + newDirectionVector);
            isChangingDirection = true;
        }

        if (isChangingDirection)
        {

            updateDirection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("opening"))
        {
            gameObject.SetActive(false);
            scoreLabel.OnCatch(this);
        }
    }

    // Referenced from unity documentation https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html
    void updateDirection()
    {

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
            //Debug.Log("Completed change");
        }
    }

    Vector3 genDirectionVector()
    {
        //Debug.Log("Generated direction");
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