using System;
using UnityEngine;

[Serializable]
public class OptionElement : MonoBehaviour
{
    public Action OnSelect;
    public Action OnDeselect;
    public bool selected { get; protected set; } = false;

    public virtual void Select() { selected = true; OnSelect?.Invoke(); }
    public virtual void Deselect() { selected = false; OnDeselect?.Invoke(); }

    public void Hide() { gameObject.SetActive(false); }
    public void Show() { gameObject.SetActive(true); }

}
