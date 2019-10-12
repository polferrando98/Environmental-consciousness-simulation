using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    [SerializeField]
    int movementsPerDay = 1;
    [SerializeField]
    float visionRange;
    [SerializeField]
    float energy;
    GameManager gm;
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override GameObject ProcessDay()
    {
        List<GameObject> foods = gm.GetFoods();
        //Daytime food hunt (just eat food for now)
        int foodCount = 0;
        for (int i = 0; i < movementsPerDay; i++)
        {
            GameObject food = FindFood(foods);

            if (food) foodCount ++;

            gm.food_manager.DestroyFood(food);
        }

        //Daytime actions
        if (foodCount == 0)
            dead = true;
        else if (foodCount > 1)
            return Reproduce();

        return null;

    }
    GameObject FindFood(List<GameObject> foods)
    {
        foreach(GameObject food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < visionRange)
            {
                EatFood(food);
                return food;
            }
        }
        visionRange = visionRange * 1.2f;
        return null;

    }
    byte EatFood(GameObject food)
    {
        //GOTO Food
        gameObject.transform.position = food.transform.position;

        gm.contamination+=0.01f;
        if (gm.contamination > 1f)
            gm.contamination = 1f;

        Graph.updateContaminationData(gm.contamination);
        return 1;
    }
    void PlantTree()
    {
        //TODO: Unimplented
    }
}
