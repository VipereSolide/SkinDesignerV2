using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ExportModelTextures : MonoBehaviour
{
    [SerializeField] private GameObject TabAlbedo;
    [SerializeField] private GameObject TabEmission;
    [SerializeField] private GameObject TabNormal;
    [SerializeField] private GameObject TabMetallic;
    [SerializeField] private GameObject TabDetail;
    [SerializeField] private GameObject TabHeight;
    [SerializeField] private GameObject TabOcclusion;
    [Space(10)]
    [SerializeField] private Toggle ToggleAlbedo;
    [SerializeField] private Toggle ToggleEmission;
    [SerializeField] private Toggle ToggleNormal;
    [SerializeField] private Toggle ToggleMetallic;
    [SerializeField] private Toggle ToggleDetail;
    [SerializeField] private Toggle ToggleHeight;
    [SerializeField] private Toggle ToggleOcclusion;

    private void GetSkillwarzPath()
    {
        DataCenter.SkillwarzDocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Skillwarz/WeaponSkins/";
    }

    private void Start()
    {
        GetSkillwarzPath();
    }

    public void ExportTextures()
    {
        Texture2D albedo = DataCenter.ModelAlbedoTexture;
        Texture2D emissive = DataCenter.ModelEmissiveTexture;
        Texture2D height = DataCenter.ModelHeightMapTexture;
        Texture2D normal = DataCenter.ModelNormalMapTexture;
        Texture2D detail = DataCenter.ModelDetailMapTexture;
        Texture2D metallic = DataCenter.ModelMetallicTexture;
        Texture2D occlusion = DataCenter.ModelOcclusionTexture;

        Debug.Log("InstantiatedModel: " + DataCenter.InstantiatedModel + "\nAlbedo: " + albedo.EncodeToPNG().Length + "\nEmissive: " + emissive.EncodeToPNG().Length);

        if(DataCenter.InstantiatedModel == null || albedo == null || emissive == null)
            return;

        //Write Texture
        if(TabAlbedo.activeSelf && ToggleAlbedo.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + ".png", albedo.EncodeToPNG());
        if(TabEmission.activeSelf && ToggleEmission.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_E.png", emissive.EncodeToPNG());
        if(TabHeight.activeSelf && ToggleHeight.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_H.png", height.EncodeToPNG());
        if(TabMetallic.activeSelf && ToggleMetallic.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_M.png", metallic.EncodeToPNG());
        if(TabDetail.activeSelf && ToggleDetail.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_D.png", detail.EncodeToPNG());
        if(TabNormal.activeSelf && ToggleNormal.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_N.png", normal.EncodeToPNG());
        if(TabOcclusion.activeSelf && ToggleOcclusion.isOn) File.WriteAllBytes(DataCenter.SkillwarzDocumentPath + DataCenter.SelectedModelName + "_O.png", occlusion.EncodeToPNG());

        transform.gameObject.SetActive(false);

    }

}