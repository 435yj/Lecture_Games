using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField] private Transform pfWoodHarvester;

    private Camera mainCamera; //카메라 선언 why 카메라를 하나만 쓰지 않을 수도 있다

    private void Start() {
        mainCamera = Camera.main; //Camera.main을 넣는 것이 효율이 좋음
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(pfWoodHarvester, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }


}
