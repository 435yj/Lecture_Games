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
        //buildingType�� buildingTypeHolder ��ũ��Ʈ�� buildingType.
        timerMax = buildingType.resourceGeneratorData.timerMax;
        //buildingType�� resourceGeneratorData�� timerMax���� timerMax�� �ִ´�.
    }

    private void Update()
    {
        timer -= Time.deltaTime; //Ÿ�̸� �ڵ� 
        if (timer <= 0f)
        {
            //timer�� 0�� �ɽ� 
            timer += timerMax;
            //timer�� timerMax�� ����.
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);

        }
    }
}
