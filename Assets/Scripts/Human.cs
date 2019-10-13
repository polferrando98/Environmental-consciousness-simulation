﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human : Entity
{
    float maxEnergy;
    float energy;
    GameManager gm;
    //How likely it to give up a descendent for a tree
    float altruism;
    [SerializeField] Vector2 plantRange;
    [SerializeField] Color bornColor;
    [SerializeField] Color normalColor;
    [SerializeField] Color deadColor;
    [SerializeField] MeshRenderer bodyRenderer;
    float maxDeathChance;
    int foodLimit;
    int n_obtainable_food;
    int next_food_index = 0;
    bool moving;

    private Animator anim;

    List<GameObject> target_foods;


    // Start is called before the first frame update
    void Awake()
    {
        moving = false;
        gm = FindObjectOfType<GameManager>();
        altruism = Parameters.HumanAltruism;
        maxEnergy = Parameters.HumanMaxEnergy;
        maxDeathChance = Parameters.HumanMaxDeathChance;
        reproductionChance = Parameters.HumanReproductionChance;
        foodLimit = Parameters.HumanFoodLimit;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            
            float speed = maxEnergy * Time.deltaTime / (gm.cycle_manager.time_to_move) ;
            //Minimum distance at which we consider we arrived at a target
            float epsilon = 0.04f;

            //If the next food hasn't been destroyed by another human we go for it
            if (target_foods[next_food_index]!=null)
            {

                Vector3 distance = target_foods[next_food_index].transform.position - gameObject.transform.position;
                distance.y = transform.position.y;

                Vector3 direction = distance.normalized;

                transform.position += direction * speed;

                //If we arrived at our target food we eat and go to the next one
                if (Mathf.Abs(distance.x) < epsilon)
                {
                    gm.food_manager.DestroyFood(target_foods[next_food_index]);
                    next_food_index++;
                }
                //If there are no targets left we stop moving
                if (next_food_index >= target_foods.Count)
                    moving = false;
            }
            else
                moving = false;

        }
    }

    public override GameObject ProcessDay()
    {

        target_foods = new List<GameObject>();
        List<GameObject> foods = gm.GetFoods();
        //Daytime food hunt (just eat food for now)
        n_obtainable_food = 0;
        FindFood(foods);

        if (target_foods.Count != 0)
        {
            //MOVE TOWARDS FOOD
            //StartCoroutine(GoToFood());
            moving = true;
            next_food_index = 0;
        }
        if (n_obtainable_food == 0)
        {
            bodyRenderer.material.SetColor("_Color", deadColor);
        }
        else
        {
            daysLived++;
            if (daysLived == 1)
                bodyRenderer.material.SetColor("_Color", normalColor);
        }
        return null;

    }
    void FindFood(List<GameObject> foods)
    {

        energy = maxEnergy;
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

            energy -= minDistance;
            if (energy > 0)
            {
                n_obtainable_food++;
                closestFood.GetComponent<Food>().found = true;
            }
            target_foods.Add(closestFood);
            referenceObject = closestFood.transform.position;

        } while (energy > 0 && n_obtainable_food < foodLimit);
    }
    void PlantTree()
    {
        Utils.SpawnObjectAroundObject(transform.position, gm.treePrefab, plantRange[0], plantRange[1], gm.GetTreeContainer(), true);
    }
    public float GetDeathGenChance()
    {
        return gm.contamination * maxDeathChance;
    }
    public GameObject TimeToEat()
    {
        //Daytime actions
        float diceRoll = Random.Range(0f,1f);
        if (diceRoll < GetDeathGenChance() || n_obtainable_food == 0)
            dead = true;
        else if (n_obtainable_food > 1) {
            diceRoll = Random.Range(0f, 1f);
            if (diceRoll < altruism)
                PlantTree();
            else
                return Reproduce(gm.humanPrefab);
        }

        return null;

    }
    public override bool Kill()
    {
        if (dead)
        {
            //Destroy(gameObject);
            anim.SetBool("dead", true);

            StartCoroutine(DieAfterSeconds(2.5f));
            return true;
        }
        return false;
    }

    IEnumerator DieAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


}
