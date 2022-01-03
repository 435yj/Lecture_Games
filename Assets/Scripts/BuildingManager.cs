using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager Instance;

    private Camera mainCamera; //카메라 선언 why 카메라를 하나만 쓰지 않을 수도 있다
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType; //BuildingTypeSO 타입을 buildingType로 선언

    private void Awake()
    {
        Instance = this;

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        //이름이 타입명과 같다면 typeof를 이용하여 불러올 수 있다. typeof(BuildingTypeListSO).Name은 BuildingTypeListSO를 불러옴
        //buildingTypeList에 값을 넣어줌 
    }

    private void Start()
    {
        mainCamera = Camera.main; //Camera.main을 넣는 것이 효율이 좋음

        //Resources.Load<BuildingTypeListSO>("BuildlingTypsList");
        //BuidlingTypeListSO 타입의 BuildingTypeList라는 이름을 가진 객체 불러오기

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //EventSystem.current.IsPointerOverGameObject() = 포인터가 EventSystem의 위에 있는지 확인
        {
            //Instantiate(transform , vector3, quaternion)
            if(activeBuildingType != null)
            //activeBuildingType이 널이 아니면 실행
            { 
            Instantiate(activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            //buildingType.prefab은 scriptableObject로 생성한 BuildingTypeSo의 오브젝트 중 선택된 오브젝트의 prefab
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Camera.Main.ScreenToWorldPoint를 이용하여 마우스 위치를 가져옴
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
        //activeBuildingType에 buildingType을 넣음
        //arrowBtn이면 null을 받음
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
        //activeBuildingType을 반환

    }

}
