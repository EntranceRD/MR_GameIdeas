using Entrance;
using System.Collections;
using UnityEngine;

public class SequenceButton : MonoBehaviour
{

    public MaterialController materialController;
    public Collider interactionCollider;

    public void SetInteraction(bool state)
    {
        interactionCollider.enabled = state;
    }

    public void Blink(float blinkTime, int times)
    {
        StartCoroutine(blink(blinkTime, times));
    }

    public void InitializeColor(Color color)
    {
        var fadedColor = color * .7f;
        materialController.SetColors(new Color[] { color, fadedColor, Color.red, Color.black });
        materialController.ChangeColor(1);
    }

    public void HighLight(float time)
    {
        StartCoroutine(highlight(time));
    }

    private IEnumerator highlight(float time)
    {
        materialController.ChangeColor(0);
        yield return new WaitForSeconds(time);
        materialController.ChangeColor(1);
    }

    private IEnumerator blink(float blinkTime, int times)
    {
        for (int i = 0; i < times; i++)
        {
            materialController.ChangeColor(2);
            yield return new WaitForSeconds(blinkTime);
            materialController.ChangeColor(3);
            yield return new WaitForSeconds(blinkTime);
        }
        materialController.ChangeColor(1);
    }
}
