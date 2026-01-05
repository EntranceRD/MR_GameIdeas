using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CarVelocityController : MonoBehaviour
{
    public float currentVelocity = 5f;
    public ClickCounterByFrame clickCounter;

    void Start()
    {
        clickCounter.OnCountedFrame += (int clicks) =>
        {
            currentVelocity *= clicks;
        };
    }

    
    void Update()
    {
        
    }
}
