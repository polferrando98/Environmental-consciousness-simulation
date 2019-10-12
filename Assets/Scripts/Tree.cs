using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Entity
{
    [SerializeField] private int maxFoodGeneration = 4;
    [SerializeField] private float chanceToGenerate = 1f;
    GameManager gm;
    [SerializeField] private Vector2 foodDropRange = new Vector2(1f,2f);
    //Offset so food doesn't spawn on our tree

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override GameObject ProcessDay()
    {
        GenFood();
        return null;
        
    }
    void GenFood()
    {
        
        for (int i = 0; i<maxFoodGeneration; i++)
        {
            float diceRoll = Random.Range(0f, 1f);
            if(diceRoll < chanceToGenerate)
            {
                GameObject newFood = Utils.SpawnObjectAroundObject(transform.position, gm.foodPrefab, foodDropRange[0], foodDropRange[1], gm.GetFoodContainer(), true);
                gm.GetFoods().Add(newFood);
            }
        }
        
    }
}
