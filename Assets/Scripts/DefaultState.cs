using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : MonoBehaviour
{
    public bool active = true;

    private void Start() {
        
        gameObject.SetActive(true);
        gameObject.SetActive(active);
         
    }
}
