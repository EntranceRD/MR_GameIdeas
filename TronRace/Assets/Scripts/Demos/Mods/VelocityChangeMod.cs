using Entrance;
using Entrance.Games.Demos;
using UnityEngine;

public enum VelocityModType
{
    IncreaseVelocity,
    DecreaseVelocity,
    TimesTwo
}

public class VelocityChangeMod : Mod
{
    public float amount;
    //private OptionButton modOption;
    public VelocityModType modType;

    private Vector3 GetModBehaviorByType(Vector3 velocity)
    {
        switch (modType)
        {
            case VelocityModType.IncreaseVelocity:
                if (velocity.x > 0)
                {
                    velocity.x += amount;
                    break;
                }
                velocity.x -= amount;
                break;
            case VelocityModType.DecreaseVelocity:
                if (velocity.x > 0)
                {
                    velocity.x = Mathf.Max(0,velocity.x - amount);
                    break;
                }
                velocity.x = Mathf.Min(0, velocity.x + amount);
                break;
            case VelocityModType.TimesTwo:
                velocity.x *= amount;
                break;
        }
        return velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<BounceBall>();
        if (obj != null)
        {
            obj.rb.velocity = GetModBehaviorByType(obj.rb.velocity);
        }
        OnUse?.Invoke();
    }
}
