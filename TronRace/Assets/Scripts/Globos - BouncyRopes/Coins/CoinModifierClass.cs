using System.Collections.Generic;
using UnityEngine;

public class CoinModifierClass : MonoBehaviour
{
    #region UNITY METHODS
    private void Awake()
    {
        Instance = this;

        coinModifiers.Add(new ModifierClass(ModifierType.TimesTwo, "x2", modifierMaterials[0]));
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region VARIABLES 
    public static CoinModifierClass Instance;
    public List<ModifierClass> coinModifiers = new List<ModifierClass>();
    public List<Material> modifierMaterials = new List<Material>();
    public const int maxCoinValue = 50;
    public const float maxCoinSize = .8f;
    #endregion

    #region PUBLIC METHODS
    public int ChangeCoinValue(int coinValue, ModifierClass modifier)
    {
        int newValue = coinValue;
        switch (modifier.type)
        {
            case ModifierType.TimesTwo:
                newValue = coinValue * 2;
                break;
            default:
                break;
        }

        if (newValue > maxCoinValue)
        {
            newValue = maxCoinValue;
        }
        return newValue;
    }

    public void ChangeCoinSize(Transform coinTransform, ModifierClass modifier)
    {
        switch (modifier.type)
        {
            case ModifierType.TimesTwo:
                coinTransform.localScale *= 2f;
                break;
            default:
                break;
        }

        if (coinTransform.localScale.x > maxCoinSize)
        {
            coinTransform.localScale = Vector3.one * maxCoinSize;
        }
    }

    public ModifierClass GetNewModifier()
    {
        return coinModifiers[0];
    }
    #endregion

    #region PRIVATE METHODS
    #endregion
}