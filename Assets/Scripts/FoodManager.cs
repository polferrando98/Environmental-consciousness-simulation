using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private GameManager gm;
    public List<GameObject> foods;

    public GameObject food_prefab;

    public GameObject foods_container;
    public int default_n_foods  =10;
    // Start is called before the first frame update
    private void Awake()
    {
        foods = new List<GameObject>();
    }

    void Start()
    {

        gm = FindObjectOfType<GameManager>();

        gm.cycle_manager.OnCycleBegin += HandleCycleBegin;
        gm.cycle_manager.OnCycleEnd += HandleCycleEnd;
    }
    void HandleCycleBegin()
    {
        GenerateAllFood();
    }

    void HandleCycleEnd()
    {

    }
    //Food to spawn in each cycle
    int NFoodsToSpawn()
    {
        return default_n_foods;
    }
    void GenerateAllFood()
    {
        //Destroy old food
        for (int i = 0; i < foods.Count; i++)
            Destroy(foods[i]);
        foods.Clear();

        //Generate new food for the day
        int foods_to_spawn = NFoodsToSpawn();

        for (int i = 0; i < foods_to_spawn; i++)
        {
            CreateFood();
        }
    }

    GameObject CreateFood()
    {
        GameObject new_food = Instantiate(food_prefab, foods_container.transform);
        new_food.transform.position = gm.GetNewSpawnPosition();
        foods.Add(new_food);
        return new_food;
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void DestroyFood(GameObject food)
    {
        foods.Remove(food);
        Destroy(food);

        /*foreach (GameObject food_go in foods)
        {
            if (food_go.GetComponent<Food>() == food)
            {
                foods.Remove(food_go);
                Destroy(food_go);
            }
        }*/
    }
}
