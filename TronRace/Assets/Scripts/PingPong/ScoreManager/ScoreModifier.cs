using System.Collections.Generic;
using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    public static ScoreModifier Instance { get; private set; }

    public List<ModifierClass> scoreModifiers = new List<ModifierClass>();
    public List<Material> modifierMaterials = new List<Material>();
    private int times2Count = 0;
    private int maxTimes2Allowed = 5;

    private void Awake()
    {
        Instance = this;

        scoreModifiers.Add(new ModifierClass(ModifierType.PlusOne, "+1", modifierMaterials[0]));
        scoreModifiers.Add(new ModifierClass(ModifierType.PlusThree, "+3", modifierMaterials[1]));
        scoreModifiers.Add(new ModifierClass(ModifierType.TimesTwo, "x2", modifierMaterials[2]));
    }

    public ModifierClass GetNewModifier()
    {
        float chance = Random.Range(0f, 1f);
        if (chance <= 0.5f && times2Count < maxTimes2Allowed)
        {
            times2Count++;
            return scoreModifiers[2];
        }

        int index = Random.Range(0,2);
        return scoreModifiers[index];
    }
}