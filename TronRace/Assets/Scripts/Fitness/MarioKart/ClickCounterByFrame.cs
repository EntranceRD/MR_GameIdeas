using System;
using Entrance.Unity;

public class ClickCounterByFrame
{
    public Action<int> OnCountedFrame;
    private int clickCounter = 0;
    Timer timeRange;

    public void OnFinish()
    {
        OnCountedFrame(clickCounter);
        clickCounter = 0;
        timeRange.Restart();
    }
}
