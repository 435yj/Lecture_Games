using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{

    private BuildingTypeSO buildingType;

    private float timer;
    private float timerMax;

    private void Awake()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        //buildingType은 buildingTypeHolder 스크립트의 buildingType.
        timerMax = buildingType.resourceGeneratorData.timerMax;
        //buildingType의 resourceGeneratorData의 timerMax값을 timerMax에 넣는다.
    }

    private void Update()
    {
        timer -= Time.deltaTime; //타이머 코드 
        if (timer <= 0f)
        {
            //timer가 0이 될시 
            timer += timerMax;
            //timer에 timerMax를 더함.
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);

        }
    }
}
