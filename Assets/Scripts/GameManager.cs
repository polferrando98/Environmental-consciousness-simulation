﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject humanPrefab;
    public GameObject foodPrefab;
    public List<GameObject> foods;
    public List<GameObject> humans;
    
    public bool activateTime = false;
    public int foodPerDay = 5;
    [SerializeField]
    private int startingHumans = 5;
    //Change for actual world limits
    public Vector4 worldLimits;

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
            Debug.Log("Length of humans " + humans.Count);
            foreach (GameObject human in humans)
            {
                human.GetComponent<Human>().PassDay();
            }
            activateTime = false;
        }   
    }
    public List<GameObject> GenerateObject(GameObject prefab, int n_spawn)
    {
        List<GameObject> list = new List<GameObject>(n_spawn);
        for (int i = 0; i < n_spawn; i++)
            list.Add(Instantiate(prefab, GetNewSpawnPosition(), Quaternion.identity));
        return list;
    }
    public void GenerateHumans()
    {
        humans = GenerateObject(humanPrefab, startingHumans);
    }
    public void GenerateFood()
    {
        foods = GenerateObject(foodPrefab, foodPerDay);
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
    public void DestroyHuman(GameObject human)
    {
        humans.Remove(human);
        Destroy(human);
    }
}
