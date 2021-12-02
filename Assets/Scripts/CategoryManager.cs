using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryManager : MonoBehaviour
{
    [Header("Category Manager")]
    [SerializeField] private GameObject[] Categories;
    [SerializeField] private CustomButton[] Buttons;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        for(int i = 0; i < Buttons.Length; i++)
        {
            if(Buttons[i].IsClicked)
            {
                for(int c = 0; c < Categories.Length; c++)
                {
                    Categories[c].SetActive(false);
                }

                Categories[i].SetActive(true);
            }
        }
    }
}
