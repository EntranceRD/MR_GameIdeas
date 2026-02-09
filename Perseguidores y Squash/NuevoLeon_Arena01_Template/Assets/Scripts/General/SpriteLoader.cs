using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance
{
    public class SpriteLoader : MonoBehaviour
    {
        private void Start()
        {
            var path = Application.streamingAssetsPath + fileName;
            display.sprite = LoadNewSprite(path);
        }

        [SerializeField] private string fileName="/file.png";
        [SerializeField] private Image display;

        public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
        {

            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
            Texture2D tex = LoadTexture(FilePath);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0), PixelsPerUnit);

            return sprite;
        }

        public Texture2D LoadTexture(string FilePath)
        {

            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails

            Texture2D Tex2D;
            byte[] FileData;

            if (File.Exists(FilePath))
            {
                FileData = File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
                if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }
            return null;                     // Return null if load failed
        }
    }
}