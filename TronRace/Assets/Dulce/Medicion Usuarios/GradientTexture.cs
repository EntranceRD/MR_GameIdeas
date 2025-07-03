using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GradientTexture : MonoBehaviour
{
    public Image image;
    public Gradient gradient;
    public Texture2D text;

    private Material material;
    private Texture2D texture;

    private void Start()
    {

    }
    private void OnEnable()
    {
        CreateTexture();

        ApplyGradient();
    }

    //private void OnValidate()
    //{
    //    CreateTexture();
    //    ApplyGradient();
    //}

    private void ApplyGradient()
    {
        if (texture == null) return;

        int textureHeight = texture.height;

        for (int y = 0; y < textureHeight; y++)
        {
            // Calculate the gradient evaluation position
            float gradientPosition = (float)y / textureHeight;

            // Evaluate the gradient at the calculated position
            Color gradientColor =  gradient.Evaluate(1-gradientPosition);
            float alpha = gradientColor.a;

            // Apply the gradient color to each pixel in the row
            for (int x = 0; x < texture.width; x++)
            {
                var originalColor = text.GetPixel(x, y);

                gradientColor.a = originalColor.a;

                texture.SetPixel(x, y,  gradientColor);
                //texture.SetPixel(x, y, text.GetPixel(x, y) * gradientColor);
            }
        }

        // Apply the changes to the texture
        texture.Apply();
    }
    private void CreateTexture()
    {
        if (image == null || image.material == null) return;
        if (text == null) return;
        material = image.material;
        texture = new Texture2D(text.width, text.height);
        material.mainTexture = texture;

    }
}
