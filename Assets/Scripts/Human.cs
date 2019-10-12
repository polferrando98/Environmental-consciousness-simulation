using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    [SerializeField]
    int movementsPerDay = 2;
    [SerializeField]
    float visionRange = 4f;
    [SerializeField]
    float energy;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PassDay()
    {
        List<GameObject> foods = gm.GetFoods();
        //Daytime food hunt (just eat food for now)
        int foodCount = 0;
        for (int i = 0; i < movementsPerDay; i++)
            foodCount += FindFood(foods);
        
        //Daytime actions
        //if (foodCount == 0)
        //    gm.DestroyHuman(gameObject);
        //else if (foodCount > 1)
        //    return Reproduce();

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
        //GOTO Food
        gameObject.transform.position = food.transform.position;

        //gm.DestroyFood(food);
        

        energy++;
        return 1;
    }
    void PlantTree()
    {
        //TODO: Unimplented
    }
    protected override GameObject Reproduce()
    {
        //TODO: Change children position so its not in the same pos as parent
        return Instantiate(gm.humanPrefab);
    }
}
