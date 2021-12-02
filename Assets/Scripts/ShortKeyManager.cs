using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShortKeyManager : MonoBehaviour
{
    [SerializeField] private Shortkey[] Shortkeys;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        for(int i = 0; i < Shortkeys.Length; i++)
        {
            if(Input.GetKeyDown(Shortkeys[i].KeyCodeA) && Input.GetKeyDown(Shortkeys[i].KeyCodeB))
            {
                Shortkeys[i].OnPressKey.Invoke();
            }
        }
    }
}
[System.Serializable]
public class Shortkey
{
    public KeyCode KeyCodeA;
    public KeyCode KeyCodeB;
    [Space(10)]
    public UnityEvent OnPressKey;
}