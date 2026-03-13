using UnityEngine;

public enum ModifierType {
    PlusOne, 
    PlusThree, 
    TimesTwo,
    Upgrade,
    Degrade
}

public class ModifierClass
{
    public ModifierType type;
    public string display;
    public Material material;

    public ModifierClass(ModifierType type, string display, Material material)
    {
        this.type = type;
        this.display = display;
        this.material = material;
    }
}
