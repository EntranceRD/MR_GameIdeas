using Entrance.Unity;
using System;
using UnityEngine;

public class ClickCounterByFrame : MonoBehaviour
{
    #region UNITY METHODS
    private void Start()
    {
        timeRange.OnFinish -= OnFinish;
        timeRange.OnFinish += OnFinish;
        timeRange.Restart();
    }

    private void Update()
    {
        timeRange.Tick(Time.deltaTime);
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            a.Click(new Entrance.Interaction.Touch());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            d.Click(new Entrance.Interaction.Touch());
        }*/
    }

    #endregion

    #region VARIABLES

    public Action<int> OnCountedFrame;
    private int clickCounter = 0;
    public Timer timeRange;
    //[SerializeField] private SimpleButton a, d;

    #endregion

    #region PUBLIC METHODS

    public void ClickOnButton()
    {
        clickCounter++;
    }

    public void OnFinish()
    {
        OnCountedFrame?.Invoke(clickCounter);
        clickCounter = 0;
        timeRange.Restart();
    }

    #endregion

    #region PRIVATE METHODS

    #endregion
}