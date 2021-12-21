using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;
    //Dictionary<1,2> 는 2의 값을 1을 키로 사용함. 1의 키를 쓰면 2의 값이 출력됨.

    private void Awake() {
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.list) {
            resourceAmountDictionary[resourceType] = 0;
            //resourcTypeList의 목록만큼 foreach를 돌리며 ResourceTypeSO 타입의 resourcType를
            //Dictionary를 사용하여 키값을 모두 0으로 초기화.
        }
        TestLogResourceAmountDictionary();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            ResourceTypeListSO resourceTypeListSO = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeListSO.list[0], 2);
            //AddREsource 함수에 list의 값에 2를 더한다
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() {
        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys) {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;
    }
}
