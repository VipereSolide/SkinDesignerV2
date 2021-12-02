using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenClickingAway : MonoBehaviour
{
    [SerializeField] private Vector4 BoxSize;

    private void Update() {
        
        if(Input.GetMouseButtonDown(0))
        {
            if(
                (Input.mousePosition.x > BoxSize.x &&
                Input.mousePosition.x < BoxSize.y &&
                Input.mousePosition.y > BoxSize.z &&
                Input.mousePosition.y < BoxSize.w)
            )
            {
                transform.gameObject.SetActive(false);
            }
        }

    }
}
