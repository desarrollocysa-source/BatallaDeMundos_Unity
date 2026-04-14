#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using BatalladeMundos;

public class ArtworkSelector : MonoBehaviour
{
    public Image previewImage;
    public CardEditorManager editor;

    public void SelectImage()
    {
#if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel("Seleccionar imagen", "", "png,jpg");

        if (!string.IsNullOrEmpty(path))
        {
            byte[] fileData = System.IO.File.ReadAllBytes(path);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);

            Sprite sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );

            // Mostrar en UI
            previewImage.sprite = sprite;

            // Mandar al editor
            editor.SetArtwork(sprite);
        }
#endif
    }
}