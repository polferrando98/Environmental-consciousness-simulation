using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private GameManager gm;
    public List<GameObject> foods;
    public List<GameObject> trees;
    public GameObject food_prefab;

    [SerializeField] GameObject tree_prefab;
    [SerializeField] int startingTrees;

    public GameObject trees_container;
    public GameObject foods_container;
    public int default_n_foods  =10;
    // Start is called before the first frame update
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        foods = new List<GameObject>();
        trees = new List<GameObject>();
        gm.cycle_manager.OnStart += HandleStart;
    }

    void Start()
    {


        gm.cycle_manager.OnCycleBegin += HandleCycleBegin;
        gm.cycle_manager.OnCycleEnd += HandleCycleEnd;
    }
    
    void HandleStart()
    {
        //Generate trees
        GenerateAllTrees();
    }
    void GenerateAllTrees()
    {
        for (int i = 0; i < startingTrees; i++)
        {
            trees.Add(CreateTree());
        }
    }
    GameObject CreateTree()
    {
        GameObject newTree = Instantiate(tree_prefab, trees_container.transform);
        newTree.transform.position = gm.GetNewSpawnPosition();
        newTree.transform.Rotate(0f, Random.Range(0f, 360f), 0f);
        return newTree;
    }
    void HandleCycleBegin()
    {
        ProcessDay();
    }
    void ProcessDay()
    {
        //Destroy old food
        for (int i = 0; i < foods.Count; i++)
            Destroy(foods[i]);
        foods.Clear();

        int nTrees = trees.Count;

        List<GameObject> newTrees = new List<GameObject>();
        for (int i = 0; i < trees.Count; i++)
        {
            GameObject newTree = trees[i].GetComponent<Tree>().ProcessDay();
            //If the tree reproduced we store the new tree
            if (newTree)
            {
                newTrees.Add(newTree);
                newTree.transform.SetParent(trees_container.transform);
            }
        }
        //Kill dead trees
        trees = trees.Where(tree => !tree.GetComponent<Tree>().Kill()).ToList();
        //print("DAY X: Started with " + nTrees + "trees, " + (nTrees - trees.Count) + " died, " + newTrees.Count + " born");
        trees.AddRange(newTrees);
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
