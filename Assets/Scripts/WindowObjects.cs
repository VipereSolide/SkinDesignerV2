using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowObjects : MonoBehaviour
{
    void Update()
    {
        if(!DataCenter.IsUIWindowOpenned && gameObject.activeSelf)
        {
            DataCenter.IsUIWindowOpenned = true;
        }
    }

    void OnDisable()
    {
        DataCenter.IsUIWindowOpenned = false;
    }
}
