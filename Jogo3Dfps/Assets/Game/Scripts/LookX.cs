using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour

{
    [SerializeField]
private float sense = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");   
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * sense;
        transform.localEulerAngles = newRotation;   
       
    }
}
