using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;

public class ApplyTexturesToModel : MonoBehaviour
{
    [SerializeField] private RawImage AlbedoTextureImage;
    [SerializeField] private RawImage EmissiveTextureImage;
    [SerializeField] private RawImage NormalTextureImage;
    [SerializeField] private RawImage HeightTextureImage;
    [SerializeField] private RawImage DetailTextureImage;
    [SerializeField] private RawImage MetallicTextureImage;
    [SerializeField] private RawImage OcclusionTextureImage;

    [SerializeField] private Texture2D NoTexture;

    private Texture ModelDefaultAlbedo;
    private Texture ModelDefaultEmissive;
    private Texture ModelDefaultNormal;
    private Texture ModelDefaultHeight;
    private Texture ModelDefaultDetail;
    private Texture ModelDefaultMetallic;
    private Texture ModelDefaultOcclusion;

    private string AlbedoLastPath;
    private string EmissiveLastPath;
    private string MetallicLastPath;
    private string NormalLastPath;
    private string HeightLastPath;
    private string DetailLastPath;
    private string OcclusionLastPath;

    private Material newMaterial;

    private void Start()
    {
        DataCenter.ApplyTexturesToModelScript = this;

        if(!string.IsNullOrEmpty(PlayerPrefs.GetString("DataCenter_LastFilePath")))
        {
            DataCenter.LastFilePath = PlayerPrefs.GetString("DataCenter_LastFilePath");
        }
    }

    private void Update()
    {
        if(AlbedoTextureImage != null && AlbedoTextureImage.texture == NoTexture)
            RemoveAlbedo();
        if(DetailTextureImage != null && DetailTextureImage.texture == NoTexture)
            RemoveDetail();
        if(EmissiveTextureImage != null && EmissiveTextureImage.texture == NoTexture)
            RemoveEmissive();
        if(HeightTextureImage != null && HeightTextureImage.texture == NoTexture)
            RemoveHeight();
        if(MetallicTextureImage != null && MetallicTextureImage.texture == NoTexture)
            RemoveMetallic();
        if(NormalTextureImage != null && NormalTextureImage.texture == NoTexture)
            RemoveNormal();
        if(OcclusionTextureImage != null && OcclusionTextureImage.texture == NoTexture)
            RemoveOcclusion();
    }

    public void ReferenceModelTextures(Material ModelMaterial)
    {
        ModelDefaultAlbedo = ModelMaterial.mainTexture;
        ModelDefaultEmissive = ModelMaterial.GetTexture("_EmissionMap");
        ModelDefaultNormal = ModelMaterial.GetTexture("_BumpMap");
        ModelDefaultHeight = ModelMaterial.GetTexture("_ParallaxMap");
        ModelDefaultDetail = ModelMaterial.GetTexture("_DetailMask");
        ModelDefaultMetallic = ModelMaterial.GetTexture("_MetallicGlossMap");
        ModelDefaultOcclusion = ModelMaterial.GetTexture("_OcclusionMap");

        DataCenter.ModelAlbedoTexture = (Texture2D)ModelDefaultAlbedo;
        DataCenter.ModelEmissiveTexture = (Texture2D)ModelDefaultEmissive;
        DataCenter.ModelNormalMapTexture = (Texture2D)ModelDefaultNormal;
        DataCenter.ModelHeightMapTexture = (Texture2D)ModelDefaultHeight;
        DataCenter.ModelDetailMapTexture = (Texture2D)ModelDefaultDetail;
        DataCenter.ModelMetallicTexture = (Texture2D)ModelDefaultMetallic;
        DataCenter.ModelOcclusionTexture = (Texture2D)ModelDefaultOcclusion;

        if(AlbedoTextureImage != null)
            RemoveAlbedo();
        if(DetailTextureImage != null)
            RemoveDetail();
        if(EmissiveLastPath != null)
            RemoveEmissive();
        if(HeightTextureImage != null)
            RemoveHeight();
        if(MetallicTextureImage != null)
            RemoveMetallic();
        if(NormalTextureImage != null)
            RemoveNormal();
        if(OcclusionTextureImage != null)
            RemoveOcclusion();
    }

    [ContextMenu("Get Shader Keywords")]
    public void GetShaderKeywords()
    {
        // Get the instance of the Shader class that the material uses
        string[] shader = DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().material.shaderKeywords;
        foreach(string s in shader)
            Debug.Log(s);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("DataCenter_LastFilePath", DataCenter.LastFilePath);
    }

    #region FindTextures

    public void FindAlbedoTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            AlbedoTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            AlbedoLastPath = m_AlbedoPath;
        }
    }

    public void FindEmissiveTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            EmissiveTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            EmissiveLastPath = m_AlbedoPath;
        }
    }

    public void FindMetallicTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            MetallicTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            MetallicLastPath = m_AlbedoPath;
        }
    }

    public void FindHeightTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            HeightTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            HeightLastPath = m_AlbedoPath;
        }
    }

    public void FindNormalTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            NormalTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            NormalLastPath = m_AlbedoPath;
        }
    }

    public void FindDetailTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            DetailTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            DetailLastPath = m_AlbedoPath;
        }
    }

    public void FindOcclusionTexture()
    {
        string m_AlbedoPath = StandaloneFileBrowser.OpenFilePanel("Select a Texture...", DataCenter.LastFilePath, "png", false)[0];

        if(!string.IsNullOrEmpty(m_AlbedoPath))
        {
            byte[] m_ImageBytes = System.IO.File.ReadAllBytes(m_AlbedoPath);
            
            Texture2D m_Texture = new Texture2D(2,2);
            m_Texture.LoadImage(m_ImageBytes);

            OcclusionTextureImage.texture = m_Texture;
            DataCenter.LastFilePath = m_AlbedoPath;
            OcclusionLastPath = m_AlbedoPath;
        }
    }

    #endregion

    #region AddTextures

    private Texture2D AddTexture(Texture tex, string _name)
    {
        if(DataCenter.InstantiatedModel == null)
            return null;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().material.EnableKeyword(_name);
        
        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().material.shaderKeywords = new string[4]{"_NORMALMAP","_METALLICGLOSSMAP","_EMISSION","_PARALLAXMAP"};

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture(_name, tex);
        return (Texture2D)tex;
    }

    public void AddAlbedo() { DataCenter.ModelAlbedoTexture = AddTexture(AlbedoTextureImage.texture, "_MainTex"); }

    public void AddEmissive() { DataCenter.ModelEmissiveTexture = AddTexture(EmissiveTextureImage.texture, "_EmissionMap"); }

    public void AddHeight() { DataCenter.ModelHeightMapTexture = AddTexture(HeightTextureImage.texture, "_ParallaxMap"); }

    public void AddMetallic() { DataCenter.ModelMetallicTexture = AddTexture(MetallicTextureImage.texture, "_MetallicGlossMap"); }

    public void AddNormal() { DataCenter.ModelNormalMapTexture = AddTexture(NormalTextureImage.texture, "_BumpMap"); }

    public void AddDetail() { DataCenter.ModelDetailMapTexture = AddTexture(DetailTextureImage.texture, "_DetailMask"); }

    public void AddOcclusion() { DataCenter.ModelOcclusionTexture = AddTexture(OcclusionTextureImage.texture, "_OcclusionMap"); }

    #endregion
 
    #region RemoveTextures

    private Texture RemoveTexture(Texture tex, string _name)
    {
        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture(_name, tex);

        return tex;
    }

    public void RemoveAlbedo()
    {
        DataCenter.ModelAlbedoTexture = ModelDefaultAlbedo as Texture2D;
        AlbedoTextureImage.texture = RemoveTexture(ModelDefaultAlbedo, "_MainTex");
    }

    public void RemoveEmissive()
    {
        DataCenter.ModelEmissiveTexture = ModelDefaultEmissive as Texture2D;
        EmissiveTextureImage.texture = RemoveTexture(ModelDefaultEmissive, "_EmissionMap");
    }   

    public void RemoveMetallic()
    {
        DataCenter.ModelMetallicTexture = ModelDefaultMetallic as Texture2D;
        MetallicTextureImage.texture = RemoveTexture(ModelDefaultMetallic, "_MetallicGlossMap");
    }

    public void RemoveDetail()
    {
        DataCenter.ModelDetailMapTexture = ModelDefaultDetail as Texture2D;
        DetailTextureImage.texture = RemoveTexture(ModelDefaultDetail, "_DetailMask");
    }

    public void RemoveHeight()
    {
        DataCenter.ModelHeightMapTexture = ModelDefaultHeight as Texture2D;
        HeightTextureImage.texture = RemoveTexture(ModelDefaultHeight, "_ParallaxMap");
    }

    public void RemoveNormal()
    {
        DataCenter.ModelNormalMapTexture = ModelDefaultNormal as Texture2D;
        NormalTextureImage.texture = RemoveTexture(ModelDefaultNormal, "_BumpMap");
    }

    public void RemoveOcclusion()
    {
        DataCenter.ModelOcclusionTexture = ModelDefaultOcclusion as Texture2D;
        OcclusionTextureImage.texture = RemoveTexture(ModelDefaultOcclusion, "_OcclusionMap");
    }

    #endregion

    #region RefreshTextures

    public void RefreshAllTextures()
    {
        Texture2D m_Texture = new Texture2D(2,2);

        byte[] AlbedoImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(AlbedoImageBytes);
        AlbedoTextureImage.texture = m_Texture;
        
        byte[] EmissiveImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(EmissiveImageBytes);
        EmissiveTextureImage.texture = m_Texture;

        byte[] MetallicImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(MetallicImageBytes);
        MetallicTextureImage.texture = m_Texture;

        byte[] HeightImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(HeightImageBytes);
        HeightTextureImage.texture = m_Texture;

        byte[] NormalImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(NormalImageBytes);
        NormalTextureImage.texture = m_Texture;

        byte[] OcclusionImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(OcclusionImageBytes);
        OcclusionTextureImage.texture = m_Texture;

        byte[] DetailImageBytes = System.IO.File.ReadAllBytes(AlbedoLastPath);
        m_Texture.LoadImage(DetailImageBytes);
        DetailTextureImage.texture = m_Texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = AlbedoTextureImage.texture;
        DataCenter.ModelAlbedoTexture = (Texture2D)AlbedoTextureImage.texture;
        
        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_EmissionMap", EmissiveTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)EmissiveTextureImage.texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_EmissionMap",  MetallicTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)MetallicTextureImage.texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_ParallaxMap", HeightTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)HeightTextureImage.texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_BumpMap", NormalTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)NormalTextureImage.texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_OcclusionMap", OcclusionTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)OcclusionTextureImage.texture;

        DataCenter.InstantiatedModel.transform.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_DetailMask", DetailTextureImage.texture);
        DataCenter.ModelAlbedoTexture = (Texture2D)DetailTextureImage.texture;
    }
    
    #endregion

    #region ExportTextures

    public void ExportAlbedo()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "A", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelAlbedoTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportMetallic()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "M", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelMetallicTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportNormal()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "N", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelNormalMapTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportDetail()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "D", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelDetailMapTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportOcclusion()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "O", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelOcclusionTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportEmissive()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "E", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelEmissiveTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    public void ExportHeight()
    {
        string path = StandaloneFileBrowser.SaveFilePanel("Export your Texture...", System.IO.Path.GetDirectoryName(DataCenter.LastFilePath), DataCenter.SelectedModelName + "_" + "H", "png");

        if(!string.IsNullOrEmpty(path))
        {
            byte[] bytes = DataCenter.ModelHeightMapTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }

    #endregion
}