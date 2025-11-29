using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GelatinousCubeDrop : MonoBehaviour
{
    [SerializeField] private List<int> modifiers = new List<int>();
    public int selectedModifier;
    public bool isTimes2;

    void Start()
    {
        //DecideModifier();
    }

    private void OnEnable()
    {
        isTimes2 = false;
        selectedModifier = 0;

        DecideModifier();
    }

    private void DecideModifier()
    {
        if (ScoreManager.Times2Count < ScoreManager.MaxTimes2Allowed)
        {
            float chance = Random.Range(0f, 1f);
            if (chance <= 0.5f)
            {
                isTimes2 = true;
                ScoreManager.Times2Count++;
                Debug.LogWarning("Aparecio un x2");
                return;
            }
        }

        selectedModifier = modifiers[Random.Range(0, modifiers.Count)];
    }
}