using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeysSaver : MonoBehaviour
{
    public KeyInput[] Inputs;
    public Slider[] Sliders;
    
    public static InputKeysSaver main;

    private void Start() {

        main = this;

    }

    private void OnEnable()
    {
        Debug.Log("Launching...");

        for(int i = 0; i < Inputs.Length; i++)
        {
            Inputs[i].Key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("KeyInputs_" + i));
            Debug.Log((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("KeyInputs_" + i)));
        }

        for(int c = 0; c < Sliders.Length; c++)
        {
            Sliders[c].value = float.Parse(PlayerPrefs.GetString("Sliders_" + c));
        }
    }

    private void Update()
    {
        main = this;

        for(int i = 0; i < Inputs.Length; i++)
        {
            PlayerPrefs.SetString("KeyInputs_" + i, Inputs[i].Key.ToString());
            PlayerPrefs.Save();
        }

        for(int c = 0; c < Sliders.Length; c++)
        {
            PlayerPrefs.SetString("Sliders_" + c, Sliders[c].value.ToString());
            PlayerPrefs.Save();
        }
    }
}