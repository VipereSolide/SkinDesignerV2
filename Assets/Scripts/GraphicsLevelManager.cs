using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsLevelManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private TMPro.TextMeshProUGUI _name;

    private string startName;

    private void Start()
    {
        startName = _name.text;
    }

    void Update()
    {
        QualitySettings.SetQualityLevel((int)slider.value, true);
        _name.text = startName + "    <i><#ffffff55>(" + InterpretQualityLevel(QualitySettings.GetQualityLevel()) + ")</color></i>";
    }

    private string InterpretQualityLevel(int level)
    {
        if(level == 0)
            return "Very Low";
        else if(level == 1)
            return "Low";
        else if(level == 2)
            return "Medium";
        else if(level == 4)
            return "High";
        else if(level == 5)
            return "Very High";
        else if(level == 6)
            return "Ultra";
        else
            return "Undefined";
    }
}
