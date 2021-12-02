using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ExtendedCanvasGroup : MonoBehaviour
{
    public enum ActiveMode { None, Dependency, AlwaysOff, AlwaysOn }
    private CanvasGroup m_CanvasGroup;

    [SerializeField] private ActiveMode _ActiveMode;
    [SerializeField] private GameObject DependencyObject;

    private float storedHeight;

    private void Start()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
        storedHeight = GetComponent<RectTransform>().sizeDelta.y;
    }

    private void Update()
    {

        if(_ActiveMode == ActiveMode.Dependency)
        {
            if(DependencyObject.activeSelf)
            {
                EnableCanvasGroup();
            }
            else
            {
                DisableCanvasGroup();
            }

        }
        else if(_ActiveMode == ActiveMode.AlwaysOff)
        {
            DisableCanvasGroup();
        }
        else if(_ActiveMode == ActiveMode.AlwaysOn)
        {
            EnableCanvasGroup();
        }

    }

    public void DisableCanvasGroup()
    {
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.interactable = false;
        m_CanvasGroup.blocksRaycasts = false;
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 0);
    }

    public void EnableCanvasGroup()
    {
        m_CanvasGroup.alpha = 1;
        m_CanvasGroup.interactable = true;
        m_CanvasGroup.blocksRaycasts = true;
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, storedHeight);
    }


}
