#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using BatalladeMundos;

public enum ImageType
{
    Artwork,
    Frame,
    WorldIcon,
    BattleIcon
}

public class UniversalImageSelector : MonoBehaviour
{
    public Image previewImage;
    public CardEditorManager editor;
    public ImageType imageType;

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

            previewImage.sprite = sprite;

            switch (imageType)
            {
                case ImageType.Artwork:
                    editor.SetArtwork(sprite);
                    break;

                case ImageType.Frame:
                    editor.SetFrame(sprite);
                    break;

                case ImageType.WorldIcon:
                    editor.SetWorldIcon(sprite);
                    break;

                case ImageType.BattleIcon:
                    editor.SetBattleIcon(sprite);
                    break;
            }
        }
#endif
    }
}