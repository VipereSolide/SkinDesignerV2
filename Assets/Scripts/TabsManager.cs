using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsManager : MonoBehaviour
{
    [Header("Tabs Manager")]
    
    [SerializeField] private List<CustomButton> Tabs;
    [SerializeField] private RectTransform[] Textures;
    [SerializeField] private CustomButton[] TabsAdders;
    [SerializeField] private Color32 SelectedTabColor;

    public CustomButton CurrentTab;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
        for( int i = 0; i < Tabs.Count; i++ )
        {
            if(Tabs[i].IsClicked)
                CurrentTab = Tabs[i];

            if(Tabs[i] != CurrentTab)
                Tabs[i].BaseColor = new Color32();

        }

        if(CurrentTab != null)
            CurrentTab.BaseColor = SelectedTabColor;


        DataCenter.CurrentTextureTab = CurrentTab;

    }

    public void RemoveCurrent()
    {
        if(CurrentTab != Tabs[0])
        {
            CurrentTab.gameObject.SetActive(false);
            TabsAdders[Tabs.IndexOf(CurrentTab)].gameObject.SetActive(true);
            Tabs[0].gameObject.SetActive(true);

            for(int i = 0; i < Textures.Length; i++)
            {
                Textures[i].gameObject.SetActive(false);
            }

            Textures[0].transform.gameObject.SetActive(true);
            CurrentTab = Tabs[0];
        }
    }
}