using Entrance;
using Newtonsoft.Json.Linq;
using System;
using TMPro;
using UnityEngine;

public class CoinModifier : MonoBehaviour
{
    public ModifierClass modifier;
    [SerializeField] private TextMeshPro modifierText;
    [SerializeField] private Vector3 targetPosition;
    public int previousColumn;
    public int nextColumn = 1;       

    public void Initialize(ModifierClass newModifier)
    {
        modifier = newModifier;
        modifierText.text = modifier.display;
        GetComponent<Renderer>().material = modifier.material;
    }

    void Start()
    {
        modifier = CoinModifierClass.Instance.GetNewModifier();
        Initialize(modifier);

        targetPosition = CoinModifiersMap.instance.GetNewPoint(nextColumn).position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2f);

        float dist = Vector3.Distance(transform.position, targetPosition);
        if (dist < 0.2f)
        {
            SelectNexPoint();
        }
    }

    private void SelectNexPoint()
    {
        if (nextColumn == 1)
        {
            if (previousColumn == 2)
                nextColumn = 0;
            else if (previousColumn == 0)
                nextColumn = 2;
        }
        else
        {
            previousColumn = nextColumn;
            nextColumn = 1;
        }

        targetPosition = CoinModifiersMap.instance.GetNewPoint(nextColumn).position;
    }
}