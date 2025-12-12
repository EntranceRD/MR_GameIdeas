using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CoinModifierClass : MonoBehaviour
{
    #region UNITY METHODS
    private void Awake()
    {
        Instance = this;

        coinModifiers.Add(new ModifierClass(ModifierType.UpgradeCoin, "Up", modifierMaterials[0]));
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
    public const int maxCoinValue = 20;
    public const float maxCoinSize = .6f;
    #endregion

    #region PUBLIC METHODS
    public int ChangeCoinValue(int coinValue, ModifierClass modifier)
    {
        switch (modifier.type)
        {
            case ModifierType.UpgradeCoin:
                switch (coinValue)
                {
                    case 1: return 2;
                    case 2: return 5;
                    case 5: return 10;
                    case 10: return 20;
                    case 20: return maxCoinValue;
                    default: return coinValue;
                }

            default:
                return coinValue; 
        }
    }


    public void ChangeCoinSize(Transform coinTransform, int coinValue, ModifierClass modifier)
    {
        float coinSize = coinTransform.localScale.x;
        float newSize = 1f;

        switch (modifier.type)
        {
            case ModifierType.UpgradeCoin:
                switch (coinValue)
                {
                    case 2: newSize = .7f; break;
                    case 5: newSize = 1f; break;
                    case 10: newSize = 1.3f; break;
                    case 20: newSize = 1.5f; break;
                    default: newSize = 1f; break;
                }
                break;
            default:
                newSize = 1f;
                break;
        }

        coinTransform.localScale = Vector3.one * 0.3f * newSize;
    }

    public ModifierClass GetNewModifier()
    {
        return coinModifiers[0];
    }
    #endregion

    #region PRIVATE METHODS
    #endregion
}