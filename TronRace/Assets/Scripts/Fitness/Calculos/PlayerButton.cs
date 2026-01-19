using Entrance;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickableElement))]
public class PlayerButton : MonoBehaviour
{
    public Action OnClick;
    private ClickableElement myButton;

    void Start()
    {
        myButton = GetComponent<ClickableElement>();
        myButton.OnClick.AddAction(() =>
        {
            OnClick?.Invoke();
        });
    }

    void Update()
    {
        
    }

    public void PressButton()
    {
        Debug.Log("Player on button");
    }

    public void ReleaseButton()
    {
        Debug.Log("Player off button");
    }   
}
