using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinModifier : MonoBehaviour
{
    public ModifierClass modifier;
    [SerializeField] private TextMeshPro modifierText;

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
    }

    void Update()
    {
        
    }
}
