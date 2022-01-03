using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager Instance;

    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;
    //<>���� �κ����� Type�� ����
    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuildingType;
    }
    //e �� EventArgs ������ �̺�Ʈ �߻��� ���õ� ������ ������ �ִ�.
    //�� �̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ�����̴�.
    //���� �� ���콺 Ŭ�� �̺�Ʈ�ÿ� ���콺�� Ŭ���� ���� ��ǥ�� �˰� �ʹٴ���
    //������ ���� ��ư���� ������ ��ư������ �˰� ���� �� e�� ������ ���� �ϸ� �� ���̴�.

    //�̺�Ʈ ó����(Event Handler) �� �̺�Ʈ�� ���ε��Ǵ� �޼����̴�.
    //�̺�Ʈ�� �߻��ϸ� �̺�Ʈ�� ����� �̺�Ʈ ó������ �ڵ尡 ����ȴ�.
    //��� �̺�Ʈ ó����� ���� ���� �� ���� �Ű������� �����Ѵ�.
    //���콺 Ŭ���Ҷ� ����Ÿ���� � ������ �˷��ִ� �� �ƴ�?

    //���� ���·� Ŭ������ ����� ������ EventArgs�� ������ �κ��� e�� �ް� e�� ���� ������ �ڵ带 ������ �� �ִ�.


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
        //mainCamera = Camera.main; //Camera.main�� �ִ� ���� ȿ���� ����
        //UtilsClass�� �ű�鼭 �ʿ䰡 ������
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
            Instantiate(activeBuildingType.prefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            //buildingType.prefab�� scriptableObject�� ������ BuildingTypeSo�� ������Ʈ �� ���õ� ������Ʈ�� prefab
            }
        }
    }

    

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
        //activeBuildingType�� buildingType�� ����
        //arrowBtn�̸� null�� ����
        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType});
        //null�� �ƴϸ� ��
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
        //activeBuildingType�� ��ȯ

    }

}
