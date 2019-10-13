using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Entity
{
    int maxFoodGeneration;
    float foodGenChance;
    [SerializeField] private Vector2 foodDropRange = new Vector2(1f,2f);


    GameManager gm;
    //Offset so food doesn't spawn on our tree

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        reproductionChance = Parameters.TreeReproductionChance;
        maxFoodGeneration = Parameters.TreeMaxFoodGeneration;
    }
  
    public float GetDeathChance()
    {        
        return (float)daysLived/50f;
    }
    public float GetFoodGenChance()
    {
        //Example sa de canviar per dinamic

        return 0.9f - gm.contamination*0.3f;
    }
    public override GameObject ProcessDay()
    {
        daysLived++;
        GenFood();
        float diceRoll = Random.Range(0f, 1f);
        dead = diceRoll < GetDeathChance();
        return Reproduce(gm.treePrefab);

    }
    void GenFood()
    {
        
        for (int i = 0; i<maxFoodGeneration; i++)
        {
            float diceRoll = Random.Range(0f, 1f);
            if(diceRoll < GetFoodGenChance())
            {
                GameObject newFood = Utils.SpawnObjectAroundObject(transform.position, gm.foodPrefab, foodDropRange[0], foodDropRange[1], gm.GetFoodContainer(), true);
                gm.GetFoods().Add(newFood);
            }
        }
        
    }

}
