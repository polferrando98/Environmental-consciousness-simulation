using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    [SerializeField]
    float maxEnergy;
    float energy;
    GameManager gm;
    [SerializeField] int foodLimit = 2;
    private int n_obtainable_food;

    bool moving;

    List<GameObject> target_foods;


    // Start is called before the first frame update
    void Awake()
    {
        moving = false;
        
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
        target_foods = new List<GameObject>();
        List<GameObject> foods = gm.GetFoods();
        //Daytime food hunt (just eat food for now)
        n_obtainable_food = 0;
        energy = maxEnergy;
        FindFood(foods);

        if (target_foods.Count != 0)
        {
            //MOVE TOWARDS FOOD
            //StartCoroutine(GoToFood());
            moving = true;
        }

        return null;

    }
    void FindFood(List<GameObject> foods)
    {

        float energyLeft = energy;
        Vector3 referenceObject = transform.position;
        do
        {
            float minDistance = float.MaxValue;
            GameObject closestFood = null;
            for (int i = 0; i < foods.Count; i++)
            {
                if (!foods[i].GetComponent<Food>().found)
                {
                    //Get closest food
                    float distance = Vector3.Distance(referenceObject, foods[i].transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestFood = foods[i];
                    }
                }
            }
            if (!closestFood)
            {
                break;
            }

            energyLeft -= minDistance;
            if (energyLeft > 0)
            {
                n_obtainable_food++;
                closestFood.GetComponent<Food>().found = true;
            }
            target_foods.Add(closestFood);
            referenceObject = closestFood.transform.position;

        } while (energyLeft > 0 && n_obtainable_food < foodLimit);

    }
    void PlantTree()
    {
        //TODO: Unimplented
    }

    public GameObject TimeToEat()
    {
        for(int i = 0; i<n_obtainable_food; i++)
        {
            gameObject.transform.position = target_foods[i].transform.position;
            gm.food_manager.DestroyFood(target_foods[i]);
        }

        //Daytime actions
        if (n_obtainable_food == 0)
            dead = true;
        else if (n_obtainable_food > 1)
            return Reproduce();

        return null;

    }

    IEnumerator GoToFood()
    {
        // suspend execution for 5 seconds
        if (target_foods.Count>0)
        {

        }

        yield return new WaitForSeconds(1);
    }

}
