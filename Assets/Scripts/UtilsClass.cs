    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass 
{

    private static Camera mainCamera;

    public static Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Camera.Main.ScreenToWorldPoint를 이용하여 마우스 위치를 가져옴
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }


}
