﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HumansManager humans_manager;
    public CycleManager cycle_manager;


    public GameObject humanPrefab;
    public GameObject foodPrefab;
    public List<GameObject> foods;

    
    public bool activateTime = false;
    public int foodPerDay = 5;
    [SerializeField]
    private int startingHumans = 5;
    //Change for actual world limits
    public Vector4 worldLimits;

    void Awake()
    {
        cycle_manager = GetComponent<CycleManager>();
        humans_manager = GetComponent<HumansManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        activateTime = false;
        GenerateHumans();



    }

    // Update is called once per frame
    void Update()
    {
        if (activateTime)
        {
            GenerateFood();

            System.Threading.Thread.Sleep(2000);
            //Human actions
            activateTime = false;
        }   
    }
    public void GenerateComponent(GameObject prefab, List<GameObject> list, int n_spawn)
    {
        list = new List<GameObject>(n_spawn);
        for (int i = 0; i < n_spawn; i++)
            list.Add(Instantiate(prefab, GetNewSpawnPosition(), Quaternion.identity));
    }
    public void GenerateHumans()
    {
        //GenerateComponent(humanPrefab, humans, startingHumans);
    }
    public void GenerateFood()
    {
        GenerateComponent(foodPrefab, foods, foodPerDay);
    }
    public Vector3 GetNewSpawnPosition()
    {
        float x = Random.Range(worldLimits[0], worldLimits[1]);
        float z = Random.Range(worldLimits[2], worldLimits[3]);
        return new Vector3(x, 0f, z);
    }
    public void DestroyFood(GameObject food)
    {
        foods.Remove(food);
        Destroy(food);
    }
}
