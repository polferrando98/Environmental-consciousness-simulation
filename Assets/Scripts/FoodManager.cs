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

    int startingTrees;
    float wasteGeneratedByEating;
    float wasteAbsorbedByTrees;
    public GameObject trees_container;
    public GameObject foods_container;

    // Start is called before the first frame update
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        foods = new List<GameObject>();
        trees = new List<GameObject>();
        gm.cycle_manager.OnStart += HandleStart;
        startingTrees = Parameters.StartingTrees;
        wasteAbsorbedByTrees = Parameters.WasteAbsorbedByTrees;
        wasteGeneratedByEating = Parameters.WasteGeneratedByEating;
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
        GameObject newTree = Instantiate(gm.treePrefab, trees_container.transform);
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
        int nTrees = trees.Count;
        Graph.updateTreeData(nTrees);

        //Reduce contamination
        gm.contamination -= wasteAbsorbedByTrees * nTrees;
        if (gm.contamination < 0f)
            gm.contamination = 0f;

        //print("Contamination: " + gm.contamination);
        //Destroy old food
        for (int i = 0; i < foods.Count; i++)
            Destroy(foods[i]);
        foods.Clear();


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
    GameObject CreateFood()
    {
        GameObject new_food = Instantiate(food_prefab, foods_container.transform);
        new_food.transform.position = gm.GetNewSpawnPosition();
        foods.Add(new_food);
        return new_food;
    }
    public void DestroyFood(GameObject food)
    {
        //Increment contamination
        gm.contamination += wasteGeneratedByEating;
        if (gm.contamination > 1f)
            gm.contamination = 1f;

        Graph.updateContaminationData(gm.contamination);

        foods.Remove(food);
        Destroy(food);
    }
}
