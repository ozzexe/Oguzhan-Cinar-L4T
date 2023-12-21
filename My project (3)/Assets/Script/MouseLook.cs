using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Range(50, 500)]
    public float sens;

    public Transform body;

    float xRot = 0f;

    public float smoothing;
    float currentRot;

    private void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        currentRot += rotX;
        currentRot = Mathf.Lerp(currentRot, 0, smoothing * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);
        body.Rotate(Vector3.up * rotX); 
    }
}
