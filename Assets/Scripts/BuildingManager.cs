using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    private Camera mainCamera; //ī�޶� ���� why ī�޶� �ϳ��� ���� ���� ���� �ִ�
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType; //BuildingTypeSO Ÿ���� buildingType�� ����

    private void Awake()
    {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        //�̸��� Ÿ�Ը�� ���ٸ� typeof�� �̿��Ͽ� �ҷ��� �� �ִ�. typeof(BuildingTypeListSO).Name�� BuildingTypeListSO�� �ҷ���
        //buildingTypeList�� ���� �־��� 

        buildingType = buildingTypeList.list[0];

    }

    private void Start()
    {
        mainCamera = Camera.main; //Camera.main�� �ִ� ���� ȿ���� ����

        //Resources.Load<BuildingTypeListSO>("BuildlingTypsList");
        //BuidlingTypeListSO Ÿ���� BuildingTypeList��� �̸��� ���� ��ü �ҷ�����

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(transform , vector3, quaternion)

            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            //buildingType.prefab�� scriptableObject�� ������ BuildingTypeSo�� ������Ʈ �� ���õ� ������Ʈ�� prefab
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
