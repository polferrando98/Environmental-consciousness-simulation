using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    const int movementsPerDay = 2;
    float visionRange = 5f;
    public float energy;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Entity PassDay(List<GameObject> foods)
    {
        //Daytime food hunt (just eat food for now)
        int foodCount = 0;
        for (int i = 0; i < movementsPerDay; i++)
            foodCount += FindFood(foods);

        //Daytime actions
        if (foodCount == 0)
            gm.DestroyHuman(gameObject);
        else if (foodCount > 1)
            return Reproduce();

        return null;

    }
    byte FindFood(List<GameObject> foods)
    {
        foreach(GameObject food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < visionRange)
                return EatFood(food);
        }
        visionRange = visionRange * 2;
        return 0;

    }
    byte EatFood(GameObject food)
    {
        //GameManager.DestroyFood(f);
        energy++;
        return 1;
    }
    void PlantTree()
    {
        //TODO: Unimplented
    }
    protected override Entity Reproduce()
    {
        return new Human();
    }
}
