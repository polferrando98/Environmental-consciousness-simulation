using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    const int MOVEMENTSPERDAY = 2;
    float visionRange = 10f;
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
    public Entity passDay(List<GameObject> foods)
    {
        //Daytime food hunt (just eat food for now)
        int foodCount = 0;
        for (int i = 0; i < MOVEMENTSPERDAY; i++)
            foodCount += findFood(foods);

        //Daytime actions
        if (foodCount == 0)
            gm.DestroyHuman(gameObject);
        else if (foodCount > 1)
            return reproduce();

        return null;

    }
    byte findFood(List<GameObject> foods)
    {
        foreach(GameObject food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < visionRange)
                return eatFood(food);
        }
        return 0;

    }
    byte eatFood(GameObject food)
    {
        //GameManager.DestroyFood(f);
        energy++;
        return 1;
    }
    void plantTree()
    {
        //TODO: Unimplented
    }
    protected override Entity reproduce()
    {
        return new Human();
    }
}
