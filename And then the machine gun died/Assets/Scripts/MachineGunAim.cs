using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAim : MonoBehaviour
{
    public float rotationSpeed;
    public LayerMask raycastLayer;
    public Transform pivotX, pivotY;
    public float minX = -30.0f, maxX = 30.0f,minY = -60.0f, maxY = 60.0f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 2000, raycastLayer);
        
        Vector3 aimPoint = hit.point;
        Quaternion targetRotation = Quaternion.LookRotation((aimPoint - pivotX.position).normalized);
        Quaternion actualRotation = Quaternion.RotateTowards(pivotX.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
        
        float x = actualRotation.eulerAngles.x;
        float y = actualRotation.eulerAngles.y;

        if(x > 180) { x -= 360; }
        if(y > 180) { y -= 360; }

        x = Mathf.Clamp(x, minX, maxX);
        y = Mathf.Clamp(y, minY, maxY);

        pivotX.localRotation = Quaternion.Euler(x, pivotX.localRotation.eulerAngles.y, pivotX.localRotation.eulerAngles.z);
        pivotY.localRotation = Quaternion.Euler(pivotY.localRotation.eulerAngles.x, y, pivotY.localRotation.eulerAngles.z);

    }
}
