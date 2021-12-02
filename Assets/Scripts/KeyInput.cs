using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyInput : MonoBehaviour
{
    [SerializeField] private TMP_Text KeyNameText;
    [SerializeField] private TMP_Text KeyText;

    [SerializeField] private string KeyName;

    public KeyCode Key;
    public bool IsListening { get; private set; }

    public void ListenToKey()
    {
        IsListening = true;
        KeyNameText.text = "Listening...";
    }

    public void RemoveKey()
    {
        IsListening = false;
        Key = KeyCode.None;
    }

    private void Update()
    {
        KeyText.text = KeyName;
        
        if(IsListening)
        {
            foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if(Input.GetKeyDown(vKey))
                {
                    IsListening = false;
                    Key = vKey;

                }
            }
        }
        else
        {
            KeyNameText.text = Key.ToString();
        }

        transform.name = "Keyinput - " + KeyName;
    }
}
