using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; } 
    //싱글톤 get으로 값을 가져갈수 있지만, private이기 때문에 값을 설정할 수 없음.

    //위 코드의 원래 코드
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
    //Dictionary<1,2> 는 2의 값을 1을 키로 사용함. 1의 키를 쓰면 2의 값이 출력됨.

    private void Awake() {
        Instance = this;

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
            //이름과 갯수를 출력
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;
        TestLogResourceAmountDictionary();
        //resourceAmountDictionary[resourceType]의 키값에 amount만큼 더한다.
    }
}
