using System.Collections.Generic;
using UnityEngine;

public class CoinModifier : MonoBehaviour
{
    public static CoinModifier Instance { get; private set; }
    //[Range(1, 20)] public int coinValue;
    //[Range(1, 100)] public int totalCoinsPerGame;
    public List<ModifierClass> coinModifiers = new List<ModifierClass>();
    public List<Material> modifierMaterials = new List<Material>();
    public const int maxCoinValue = 50;
    public const float maxCoinSize = 5.0f;

    private void Awake()
    {
        Instance = this;

        coinModifiers.Add(new ModifierClass(ModifierType.TimesTwo, "x2", modifierMaterials[0]));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int ChangeCoinValue(int coinValue, ModifierClass modifier)
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

    private void ChangeCoinSize(Transform coinTransform, ModifierClass modifier)
    {
        switch (modifier.type)
        {
            case ModifierType.TimesTwo:
                coinTransform.localScale = Vector3.one * 1.5f;
                break;
            default:
                break;
        }

        if (coinTransform.localScale.x > maxCoinSize)
        {
            coinTransform.localScale = Vector3.one * maxCoinSize;
        }
    }
}
