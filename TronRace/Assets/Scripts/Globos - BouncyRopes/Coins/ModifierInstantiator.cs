using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Unity;
using Entrance;

public class ModifierInstantiator : MonoBehaviour
{
    private void Awake()
    {
        instanceTimer.OnFinish = () =>
        {
            InstantiateModifier();
            instanceTimer.Restart();
        };

        instanceTimer.Restart();
    }

    private void Update()
    {
        instanceTimer.Tick(Time.deltaTime);
    }

    [SerializeField] private Timer instanceTimer;
    [SerializeField] private ObjectInstantiator modifierInstantiator;
    [SerializeField] private ObjectGroup<Transform> instancePoints;

    private void InstantiateModifier()
    {
        int rand = Random.Range(0, instancePoints.objects.Count);
        var point = instancePoints.GetObject(rand);
        var modifierObj = modifierInstantiator.Instantiate(point);

        var coinModifier = modifierObj.GetComponent<CoinModifier>();
        if (rand < instancePoints.objects.Count / 2)
            coinModifier.previousColumn = 0;
        else
            coinModifier.previousColumn = 2;
    }

}
