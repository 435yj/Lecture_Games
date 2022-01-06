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
            if (activeBuildingType != null && CanSpawnBuilding(activeBuildingType, UtilsClass.GetMouseWorldPosition()))
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
        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType });
        //null�� �ƴϸ� ��
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
        //activeBuildingType�� ��ȯ

    }


    private bool CanSpawnBuilding(BuildingTypeSO buildingType, Vector3 position)
    {
        BoxCollider2D boxCollider2D = buildingType.prefab.GetComponent<BoxCollider2D>();

        Collider2D[] collider2DArray = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size, 0);
        //Box��� position�� �߽����� boxCollider2D�� size��ŭ ȸ���� 0
        //OverlapBoxAll(��ġ(Vector2), ������(Vector2), ����(float))
        //�������� collider2DArray�� �迭�� �־���

        bool isAreaClear = collider2DArray.Length == 0;
        //collider2DArray.Length�� 0�̶� ���Ͽ� 0�̶�� ���� ��ȯ �ƴϸ� ������ ��ȯ   
        if (!isAreaClear) return false;

        collider2DArray = Physics2D.OverlapCircleAll(position, buildingType.minConstructionRadius);
        //���� ��ġ�°� �迭�� �������

        foreach (Collider2D collider2D in collider2DArray)
        //collider2DArray��ŭ �ݺ�
        {
            BuildingTypeHolder buildingTypeHolder = collider2D.GetComponent<BuildingTypeHolder>();

            if (buildingTypeHolder != null)
            //buildingTypeHolder�� null�� �ƴϸ� 
            {
                if (buildingTypeHolder.buildingType == buildingType)
                //buildingTypeHolder.buildingType�� buildikngType�� ������ false�� return�Ͽ� ��ġ �Ұ�
                {
                    return false;
                }
            }
        }

        float maxConstructionRadius = 25f;
        collider2DArray = Physics2D.OverlapCircleAll(position, maxConstructionRadius);
        //���� ��ġ�°� �迭�� �������

        foreach (Collider2D collider2D in collider2DArray)
        //collider2DArray��ŭ �ݺ�
        {
            BuildingTypeHolder buildingTypeHolder = collider2D.GetComponent<BuildingTypeHolder>();

            if (buildingTypeHolder != null)
            //buildingTypeHolder�� null�� �ƴϸ� 
            {
                return true;
            }
        }

        return false;
    }
}
