using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using FeatherTools.PRO.Serialization;

public class UIThemeManager : MonoBehaviour
{
    public ThemeObject_Image[] ThemeObjectsImages;
    public ThemeObject_TMProText[] ThemeObjectsTexts;

    public List<ThemeObject_Image> FinalThemeObjectsImages = new List<ThemeObject_Image>();

    private const string THEMEOBJECTKEY = "_";

    private void Start()
    {
        ApplyThemeObjects();

        if(PopulateThemeObjects())
        {
            SaveThemeObjects();
        }

        CompileThemeObjects();
    }

    private bool PopulateThemeObjects()
    {
        for(int i = 0; i < ThemeObjectsImages.Length; i++)
        {
            Image[] images = GameObject.FindObjectsOfType<Image>();

            for(int imagesLength = 0; imagesLength < images.Length; imagesLength++)
            {
                if(images[imagesLength].color == ThemeObjectsImages[i].ImageColor)
                {
                    ThemeObjectsImages[i].ImageElements.Add(images[imagesLength]);
                }
            }
        }

        for(int i = 0; i < ThemeObjectsTexts.Length; i++)
        {
            TMP_Text[] texts = GameObject.FindObjectsOfType<TMP_Text>();

            for(int textsLength = 0; textsLength < texts.Length; textsLength++)
            {
                if(texts[textsLength].color == ThemeObjectsTexts[i].ImageColor)
                {
                    ThemeObjectsTexts[i].ImageElements.Add(texts[textsLength]);
                }
            }
        }

        return true;
    }

    private void SaveThemeObjects()
    {
        Directory.CreateDirectory("./Assets/Saved/");

        SaveSystem.SerializeToJSON(ThemeObjectsImages, "./Assets/Saved/ThemeObjectsImages.sds");
        SaveSystem.SerializeToJSON(ThemeObjectsTexts, "./Assets/Saved/ThemeObjectsTexts.sds");
    }

    public void CompileThemeObjects()
    {
        string totalContent = "";

        for(int i = 0; i < ThemeObjectsImages.Length; i++)
        {
            string content = "";

            content += ThemeObjectsImages[i].Name;
            content += "\nColor: rgba(" + ThemeObjectsImages[i].ImageColor.r + ", " + ThemeObjectsImages[i].ImageColor.g + ", " + ThemeObjectsImages[i].ImageColor.b + ", " +  + ThemeObjectsImages[i].ImageColor.a + ")";
            content += "\n\n" + THEMEOBJECTKEY + "\n\n";

            totalContent += content;
        }

        File.WriteAllText("./Assets/Saved/CurrentTheme.sds", totalContent);
    }

    public string[] DecompileThemeObjects()
    {
        string readFile = File.ReadAllText("./Assets/Saved/CurrentTheme.sds");
        string[] fileCells = readFile.Split(THEMEOBJECTKEY.ToCharArray());

        for(int i = 0; i < fileCells.Length; i++)
        {   
            fileCells[i] = fileCells[i].Replace("\n\n","");
        }

        return fileCells;
    }

    public void ApplyThemeObjects()
    {
        string[] cells = DecompileThemeObjects();

        for(int i = 0; i < cells.Length - 1; i++)
        {
            string[] lines = cells[i].Split( ("\n").ToCharArray() );

            ThemeObject_Image img = new ThemeObject_Image();
            img.Name = lines[0];
            
            string r = "";
            string g = "";
            string b = "";
            string a = "";

            r = lines[1].Split('(')[1].Split(')')[0].Split(',')[0];
            g = lines[1].Split('(')[1].Split(')')[0].Split(',')[1];
            b = lines[1].Split('(')[1].Split(')')[0].Split(',')[2];
            a = lines[1].Split('(')[1].Split(')')[0].Split(',')[3];

            img.ImageColor = new Color32(
                byte.Parse(r),
                byte.Parse(g),
                byte.Parse(b),
                byte.Parse(a)
            );


            FinalThemeObjectsImages.Add(img);
        }

        for(int c = 0; c < FinalThemeObjectsImages.Count; c++)
        {
            FinalThemeObjectsImages[c].ImageElements = ThemeObjectsImages[c].ImageElements;

            ApplyColor();
        }
    }

    [ContextMenu("Apply Color")]
    private void ApplyColor()
    {
        for(int c = 0; c < FinalThemeObjectsImages.Count; c++)
        {
            for(int i = 0; i < FinalThemeObjectsImages[c].ImageElements.Count; i++)
            {
                FinalThemeObjectsImages[c].ImageElements[i].color = FinalThemeObjectsImages[c].ImageColor;
            }
        }
    }
}
[System.Serializable]
public class ThemeObject_Image
{
    public string Name;
    public List<Image> ImageElements = new List<Image>();
    public Color32 ImageColor;
}

[System.Serializable]
public class ThemeObject_TMProText
{
    public string Name;
    public List<TMP_Text> ImageElements = new List<TMP_Text>();
    public Color32 ImageColor;
}