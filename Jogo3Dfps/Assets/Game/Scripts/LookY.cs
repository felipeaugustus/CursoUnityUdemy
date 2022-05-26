using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
   private float sensey = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");   
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * sensey;
        transform.localEulerAngles = newRotation; 
        
    }
}
