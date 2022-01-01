using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    //�̱��� get���� ���� �������� ������, private�̱� ������ ���� ������ �� ����.

    //�� �ڵ��� ���� �ڵ�
    /*
    private static ResourceManager instance;
    public static ResourceManager GetInstance() {
        return instance;
    }
    private static void SetInstance(ResourceManager set) {
        instance = set;
    }
    */

    public event EventHandler OnResourceAmountChanged;
    //event�� ����Ϸ��� using Systema�� ����
    //public event EventHandler �̺�Ʈ-�̸� // �̺�Ʈ ����

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;
    //Dictionary<1,2> �� 2�� ���� 1�� Ű�� �����. 1�� Ű�� ���� 2�� ���� ��µ�.

    private void Awake()
    {
        Instance = this;
        //�̱����� ����ϱ� ���� ���������� ������ ResourceManager�� Instance�� �� ������Ʈ�� ������.

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();
        //resourceAmountDictionary�� Dictionary<ResourceTypesSO, int> ������ Dictionary�� ����

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        //Resources ������ ResourceTypeListSO��� �̸��� ResourceTypeListSO�� ����Ʈ�� �����´�

        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
            //resourcTypeList�� ��ϸ�ŭ foreach�� ������ ResourceTypeSO Ÿ���� resourcType��
            //Dictionary�� ����Ͽ� Ű���� ��� 0���� �ʱ�ȭ.
        }
        TestLogResourceAmountDictionary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResourceTypeListSO resourceTypeListSO = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeListSO.list[0], 2);
            //AddREsource �Լ��� list�� ���� 2�� ���Ѵ�
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
            //�̸��� ������ ���
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        //�Ʒ� �ڵ�� ���� �ǹ�
        //OnResourceAmountChanged��� Event�� � �Լ��� ������ ������ 
        /*if(OnResourceAmountChanged != null)
        {
            OnResourceAmountChanged(this, EventArgs.Empty);
        }*/
        //this�� �� ������Ʈ�� �����ٴ� ��, EventArgs.Empty�� Event�Ķ���ͷ� ���� ���� ���� ��
        //null�� ���� �� e�� �޾Ұ� e�� ���𰡸� �õ��� �� �߻��ϴ� �������� Null ���� ������ ���ϱ� ����.

        TestLogResourceAmountDictionary();
        //resourceAmountDictionary[resourceType]�� Ű���� amount��ŭ ���Ѵ�.
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    //ResourceTypeSO���·� �Ű������� �޾� resourceAmountDictionary�� ���
    {
        return resourceAmountDictionary[resourceType];
        //int������ �Լ��� �����߱� ������ ��ȯ�� �ؾ��Ѵ�.
        //resourceType�� Ű ���� resourceAmountDictionary�� return���� ��ȯ�Ѵ�.
    }
}
