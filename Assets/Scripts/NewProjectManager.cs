using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class NewProjectManager : MonoBehaviour
{
    [SerializeField] private List<ModelSO> WeaponModels = new List<ModelSO>();
    [SerializeField] private Image WeaponImage;
    [SerializeField] private GameObject WeaponContainer;
    [SerializeField] private GameObject LeftHeader;

    public GameObject SelectedModel {get; private set;}
    public GameObject CurrentModel {get; private set;}

    public void SelectModel(int modelIndex)
    {
        ModelSO choosenModel = WeaponModels[modelIndex];
        WeaponImage.sprite = choosenModel.WeaponImageInGUI;

        SelectedModel = choosenModel.WeaponInstantiatedModel;

        DataCenter.SelectedModelName = choosenModel.WeaponNameInGUI;
    }

    public void InstantiateModel()
    {
        if(SelectedModel == null)
            return;

        Destroy(CurrentModel);

        CurrentModel = Instantiate(SelectedModel, WeaponContainer.transform);
        DataCenter.InstantiatedModel = CurrentModel;

        LeftHeader.SetActive(true);
        transform.gameObject.SetActive(false);

        Debug.LogWarning(CurrentModel.GetComponents<Renderer>()[0].material);
        DataCenter.ApplyTexturesToModelScript.ReferenceModelTextures(CurrentModel.GetComponents<Renderer>()[0].material);

    }
}