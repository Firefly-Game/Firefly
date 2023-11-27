using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : FireflyBehaviour
{
    public FireflySpawner spawner;
    
    void Start()
    {
        
        InitValues();
        Type = FireflyType.Moth;
        SetColor();
        SetPosition();
    }

    void SetPosition()
    {
        transform.position = spawner.GetPositionOnSphere();
    }

    
}
