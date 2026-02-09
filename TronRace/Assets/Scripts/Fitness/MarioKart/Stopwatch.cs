using System;
using System.Collections.Generic;
using System.Diagnostics;

[Serializable]
public class Stopwatch
{
    public Action OnFinish;
    public float Target = 1f;
    private float initialTime = 0f;
    public float currentTime { get; protected set; } = 0f;

    public void Restart()
    {
        currentTime = Math.Abs(initialTime);
    }

    public void Tick(float time)
    {
        if(!(currentTime >= Target))
        {
            currentTime = Math.Min(currentTime + time, Target);
            if (currentTime >= Target)
            {
                OnFinish?.Invoke();
            }
        }
    }
}
