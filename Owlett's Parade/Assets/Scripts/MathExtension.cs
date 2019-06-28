using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtension
{
    public static Vector3 MouseWorldPosition()
    {
        Vector3 mousePosition = Vector3.zero;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Floor")))
        {
            mousePosition = hit.point;
        }

        return mousePosition;
    }
}
