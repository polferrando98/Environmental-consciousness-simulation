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

    private int food_count;

    Food food_found;
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();

            
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override GameObject ProcessDay()
    {
        List<GameObject> foods = gm.GetFoods();
        //Daytime food hunt (just eat food for now)
        food_count = 0;
        for (int i = 0; i < movementsPerDay; i++)
        {
            GameObject food = FindFood(foods);

            if (food)
            {
                food_count++;



            }
        }

        //StartCoroutine(GoToFood());

        //Daytime actions
        if (food_count == 0)
            dead = true;
        else if (food_count > 1)
            return Reproduce();

        return null;

    }
    GameObject FindFood(List<GameObject> foods)
    {
        foreach(GameObject food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < visionRange)
            {
                food_found = food.GetComponent<Food>();
                if (food_found.found == false)
                {
                    
                    food_found.found = true;

                    return food;
                }
            }
        }
        visionRange = visionRange * 1.2f;
        return null;

    }
    byte EatFood()
    {
        energy++;
        return 1;
    }
    void PlantTree()
    {
        //TODO: Unimplented
    }

    public void TimeToEat()
    {
        if (gameObject && food_found)
        {
            gameObject.transform.position = food_found.transform.position;
            EatFood();
            gm.food_manager.DestroyFood(food_found.gameObject);
        }

    }

    //IEnumerator GoToFood()
    //{
    //    // suspend execution for 5 seconds
    //    if (food_found) { 

    //}

    //    yield return new WaitForSeconds(1);

    //    //GOTO Food
    //    //gameObject.transform.position = food.transform.position;

    //}
}
