using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorChanger : MonoBehaviour
{
    public MaterialController materialController;
    [SerializeField] private float colorChangeSpeed = 5f;
    private float colorHUE = 0f;

    private void Update()
    {
        colorHUE = (colorHUE+(colorChangeSpeed * Time.deltaTime));
        var hue = (colorHUE % 360)/360f;
        var col = Color.HSVToRGB(hue, 1, 1);
        materialController.ChangeColor(col);
    }
}
