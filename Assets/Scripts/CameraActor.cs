using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraActor : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 0.25f;
    [SerializeField] private bool RotatesAroundObject = true;
    [SerializeField] private GameObject m_Camera;
    [SerializeField] private Slider RotateSpeedSlider;
    [SerializeField] private Slider ManualRotateSpeedSlider;
    [Space()]
    [SerializeField] private KeyInput RotateModelInput;

    private void Update()
    {
        if(RotatesAroundObject && !Input.GetKey(RotateModelInput.Key))
        {
            transform.localEulerAngles += new Vector3(0,RotateSpeed * Time.deltaTime * RotateSpeedSlider.value,0);
        }

        if(DataCenter.IsMouseOutOfUI && !DataCenter.IsUIWindowOpenned)
        {
            m_Camera.transform.position += m_Camera.transform.forward * Input.GetAxis("Mouse ScrollWheel");

            if(Input.GetKey(RotateModelInput.Key))
                transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * 2 * ManualRotateSpeedSlider.value, Input.GetAxis("Mouse X") * 2 * ManualRotateSpeedSlider.value, 0);
        }
    }
}