using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Color")]
    [SerializeField] private Color32 HighlightColor;
    [SerializeField] private Color32 ClickColor;

    public bool IsHighlighted { get; private set; }
    public bool IsClicked { get; private set; }

    [HideInInspector]
    public Color32 BaseColor;

    private Image m_Image;

    public bool IsDebugging;

    private void Start()
    {
        m_Image = transform.GetComponent<Image>();
        BaseColor = m_Image.color;

    }

    public void OnPointerEnter(PointerEventData data) { IsHighlighted = true; }
    public void OnPointerExit(PointerEventData data) { IsHighlighted = false; }

    public void OnPointerDown(PointerEventData data) { IsClicked = true; }
    public void OnPointerUp(PointerEventData data) { IsClicked = false; }

    private void Update()
    {

        if(IsDebugging)
            Debug.Log("State: Highlighted=" + IsHighlighted + " | Clicked=" + IsClicked + "| BaseColor = rgba(" + BaseColor.r + "," + BaseColor.g + "," + BaseColor.b + "," + BaseColor.a + ")");

        if(IsHighlighted)
        {
            if(IsClicked)
            {
                m_Image.color = ClickColor;
            }
            else
                m_Image.color = HighlightColor;
        }
        else
        {
            m_Image.color = BaseColor;
        }
            
    }
}
