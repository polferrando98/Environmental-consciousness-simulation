using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HumansManager humans_manager;
    public FoodManager food_manager;
    public CycleManager cycle_manager;


    public GameObject humanPrefab;
    public GameObject foodPrefab;
    public GameObject treePrefab;



    private Collider boundaries;

    public float contamination = 0;

    void Awake()
    {
        boundaries = GameObject.FindGameObjectsWithTag("Boundary")[0].GetComponent<Collider>();
        cycle_manager = GetComponent<CycleManager>();
        humans_manager = GetComponent<HumansManager>();
        food_manager = GetComponent<FoodManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public List<GameObject> GetFoods()
    {
        return food_manager.foods;
    }
    public Transform GetFoodContainer()
    {
        return food_manager.foods_container.transform;
    }
    public Transform GetTreeContainer()
    {
        return food_manager.trees_container.transform;
    }
    public Collider GetCollider()
    {
        return boundaries; 
    }
    public Vector3 GetNewSpawnPosition()
    {
        float x = Random.Range(boundaries.transform.position.x-boundaries.bounds.size.x/2f, 
            boundaries.transform.position.x + boundaries.bounds.size.x / 2f);
        float z = Random.Range(boundaries.transform.position.z - boundaries.bounds.size.z / 2f,
            boundaries.transform.position.z + boundaries.bounds.size.z / 2f);
        return new Vector3(x, 0f, z);
    }
}
