using DG.Tweening;
using Entrance;
using System.Collections;
using TMPro;
using UnityEngine;

public class GelatinousCubeDrop : MonoBehaviour
{
    #region UNITY_METHODS
    public void Initialize(ModifierClass newModifier)
    {
        modifier = newModifier;
        modifierText.text = modifier.display;
        GetComponent<Renderer>().material = modifier.material;
        modifierText.transform.localScale = Vector3.one;
        modifierText.color = new Color(1f, 1f, 1f, 0.5f);
        //modifierText.gameObject.SetActive(false);
    }
    #endregion

    #region VARIABLES
    public ModifierClass modifier;
    [SerializeField] private TextMeshPro modifierText;
    #endregion

    #region PUBLIC_METHODS
    public IEnumerator ShowModifier()
    {
        //modifierText.gameObject.SetActive(true);

        // Reset
        modifierText.transform.localScale = Vector3.one;
        modifierText.color = new Color(1f, 1f, 1f, 1f);

        // 1) Escalamos a 1.2 en 0.2 segundos
        yield return modifierText.transform
            .DOScale(1.2f, 0.2f)
            .SetEase(Ease.OutBack)
            .WaitForCompletion();

        // 2) Escalamos a 0 en 0.3 segundos
        yield return modifierText.transform
            .DOScale(0f, 0.3f)
            .SetEase(Ease.InBack)
            .WaitForCompletion();

        //modifierText.gameObject.SetActive(false);
    }
    #endregion
}