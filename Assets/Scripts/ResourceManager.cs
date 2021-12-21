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

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;
    //Dictionary<1,2> �� 2�� ���� 1�� Ű�� �����. 1�� Ű�� ���� 2�� ���� ��µ�.

    private void Awake() {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.list) {
            resourceAmountDictionary[resourceType] = 0;
            //resourcTypeList�� ��ϸ�ŭ foreach�� ������ ResourceTypeSO Ÿ���� resourcType��
            //Dictionary�� ����Ͽ� Ű���� ��� 0���� �ʱ�ȭ.
        }
        TestLogResourceAmountDictionary();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            ResourceTypeListSO resourceTypeListSO = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeListSO.list[0], 2);
            //AddREsource �Լ��� list�� ���� 2�� ���Ѵ�
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() {
        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys) {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
            //�̸��� ������ ���
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;
        TestLogResourceAmountDictionary();
        //resourceAmountDictionary[resourceType]�� Ű���� amount��ŭ ���Ѵ�.
    }
}
