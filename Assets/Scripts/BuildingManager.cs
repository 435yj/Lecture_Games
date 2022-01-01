using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    private Camera mainCamera; //카메라 선언 why 카메라를 하나만 쓰지 않을 수도 있다
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType; //BuildingTypeSO 타입을 buildingType로 선언

    private void Awake()
    {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        //이름이 타입명과 같다면 typeof를 이용하여 불러올 수 있다. typeof(BuildingTypeListSO).Name은 BuildingTypeListSO를 불러옴
        //buildingTypeList에 값을 넣어줌 

        buildingType = buildingTypeList.list[0];

    }

    private void Start()
    {
        mainCamera = Camera.main; //Camera.main을 넣는 것이 효율이 좋음

        //Resources.Load<BuildingTypeListSO>("BuildlingTypsList");
        //BuidlingTypeListSO 타입의 BuildingTypeList라는 이름을 가진 객체 불러오기

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(transform , vector3, quaternion)

            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            //buildingType.prefab은 scriptableObject로 생성한 BuildingTypeSo의 오브젝트 중 선택된 오브젝트의 prefab
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }


}
