using DG.Tweening;
using Entrance;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CoinModifier : MonoBehaviour
{
    #region UNITY METHODS
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
        SelectNextColumn();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * modifierVelocity);

        float dist = Vector3.Distance(transform.position, targetPosition);
        if (dist < 0.2f)
        {
            SelectNextColumn();
        }
    }
    #endregion

    #region VARIABLES
    public ModifierClass modifier;
    [SerializeField] private TextMeshPro modifierText;
    [SerializeField, Range(0, 3)] private float modifierVelocity;
    [SerializeField] private PoolableObject poolable;
    [SerializeField] private Vector3 targetPosition;
    public int previousColumn;
    private int totalColumns = 3;
    public int nextColumn;
    #endregion

    #region PUBLIC METHODS
    #endregion

    #region PRIVATE METHODS
    private void SelectNextColumn()
    {
        previousColumn = nextColumn;
        nextColumn = (previousColumn + 1) % totalColumns;
        targetPosition = CoinModifiersMap.instance.GetNewPoint(nextColumn).position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var balloon = other.GetComponent<Balloon>();
        if (balloon == null) return;

        balloon.value = CoinModifierClass.Instance.ChangeCoinValue(balloon.value, modifier);
        CoinModifierClass.Instance.ChangeCoinSize(balloon.transform,balloon.value, modifier);
        balloon.UpdateValueTxt();

        poolable.Recycle();
    }

    #endregion
}