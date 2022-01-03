using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager Instance;

    private Camera mainCamera; //ī�޶� ���� why ī�޶� �ϳ��� ���� ���� ���� �ִ�
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType; //BuildingTypeSO Ÿ���� buildingType�� ����

    private void Awake()
    {
        Instance = this;

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        //�̸��� Ÿ�Ը�� ���ٸ� typeof�� �̿��Ͽ� �ҷ��� �� �ִ�. typeof(BuildingTypeListSO).Name�� BuildingTypeListSO�� �ҷ���
        //buildingTypeList�� ���� �־��� 
    }

    private void Start()
    {
        mainCamera = Camera.main; //Camera.main�� �ִ� ���� ȿ���� ����

        //Resources.Load<BuildingTypeListSO>("BuildlingTypsList");
        //BuidlingTypeListSO Ÿ���� BuildingTypeList��� �̸��� ���� ��ü �ҷ�����

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //EventSystem.current.IsPointerOverGameObject() = �����Ͱ� EventSystem�� ���� �ִ��� Ȯ��
        {
            //Instantiate(transform , vector3, quaternion)
            if(activeBuildingType != null)
            //activeBuildingType�� ���� �ƴϸ� ����
            { 
            Instantiate(activeBuildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            //buildingType.prefab�� scriptableObject�� ������ BuildingTypeSo�� ������Ʈ �� ���õ� ������Ʈ�� prefab
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Camera.Main.ScreenToWorldPoint�� �̿��Ͽ� ���콺 ��ġ�� ������
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
        //activeBuildingType�� buildingType�� ����
        //arrowBtn�̸� null�� ����
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
        //activeBuildingType�� ��ȯ

    }

}
