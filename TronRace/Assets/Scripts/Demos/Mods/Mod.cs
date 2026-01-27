using Entrance;
using Entrance.Games.Demos;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mod : MonoBehaviour
{
    public string modName;
    public TextMeshProUGUI textMeshPro;
    public PoolableObject pool;
    public Action OnUse;

    private void Awake()
    {
        textMeshPro.text = modName;
        OnUse += RecycleMod;
    }

    public void RecycleMod()
    {
        pool.Recycle();
    }
}
