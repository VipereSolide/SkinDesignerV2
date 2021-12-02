using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataCenter
{
    public static string SkillwarzDocumentPath;

    public static GameObject InstantiatedModel;

    public static Texture2D ModelAlbedoTexture;
    public static Texture2D ModelEmissiveTexture;
    public static Texture2D ModelHeightMapTexture;
    public static Texture2D ModelNormalMapTexture;
    public static Texture2D ModelMetallicTexture;
    public static Texture2D ModelDetailMapTexture;
    public static Texture2D ModelOcclusionTexture;

    public static string SelectedModelName;

    public static Vector4 FreeSpace = new Vector4(500,847,1919,-49);

    public static ApplyTexturesToModel ApplyTexturesToModelScript;

    public static bool IsUIWindowOpenned = false;

    public static Texture2D SpriteToTexture2D(Sprite sprite)
    {
        Texture2D m_Texture2D = new Texture2D( (int)sprite.rect.width, (int)sprite.rect.height );

        var m_Pixels = sprite.texture.GetPixels(
            (int)sprite.textureRect.x,
            (int)sprite.textureRect.y,
            (int)sprite.textureRect.width,
            (int)sprite.textureRect.height
        );

        m_Texture2D.SetPixels(m_Pixels);
        m_Texture2D.Apply();

        return m_Texture2D;
    }

    public static bool IsMouseOutOfUI { get { return (Input.mousePosition.x > DataCenter.FreeSpace.x && Input.mousePosition.x < DataCenter.FreeSpace.z && Input.mousePosition.y < DataCenter.FreeSpace.y && Input.mousePosition.y > DataCenter.FreeSpace.w); } }

    public static string LastFilePath = "./";

    public static CustomButton CurrentTextureTab;
}