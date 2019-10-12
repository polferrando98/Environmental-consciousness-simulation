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

    public bool moving;

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
        if (moving)
        { 
                float speed = 0.5f;

                Vector3 direction = target_foods[0].transform.position - gameObject.transform.position ;

                direction.y = 0;

                direction = direction.normalized;

                transform.position += direction * speed;

        }

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
        moving = true;
    }
    void PlantTree()
    {
        //TODO: Unimplented
    }

    public GameObject TimeToEat()
    {
        moving = false;
        for(int i = 0; i<n_obtainable_food; i++)
        {
            gm.food_manager.DestroyFood(target_foods[i]);

            gm.contamination += 0.01f;
            if (gm.contamination > 1f)
                gm.contamination = 1f;

            Graph.updateContaminationData(gm.contamination);
        }

        //Daytime actions
        if (n_obtainable_food == 0)
            dead = true;
        else if (n_obtainable_food > 1)
            return Reproduce();

        return null;

    }



}
