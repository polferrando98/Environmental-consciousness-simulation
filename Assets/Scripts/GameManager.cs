using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HumansManager humans_manager;
    public CycleManager cycle_manager;


    public GameObject humanPrefab;
    public GameObject foodPrefab;
    public List<GameObject> foods;

    
    public bool activateTime = false;
    public int foodPerDay = 5;
    [SerializeField]
    private int startingHumans = 5;
    //Change for actual world limits
    public Vector4 worldLimits;

    void Awake()
    {
        cycle_manager = GetComponent<CycleManager>();
        humans_manager = GetComponent<HumansManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateHumans();



    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public List<GameObject> GenerateObject(GameObject prefab, int n_spawn)
    {
        List<GameObject> list = new List<GameObject>(n_spawn);
        for (int i = 0; i < n_spawn; i++)
            list.Add(Instantiate(prefab, GetNewSpawnPosition(), Quaternion.identity));
        return list;
    }
    public void GenerateHumans()
    {

    }
    public void GenerateFood()
    {
        foods = GenerateObject(foodPrefab, foodPerDay);
    }
    public Vector3 GetNewSpawnPosition()
    {
        float x = Random.Range(worldLimits[0], worldLimits[1]);
        float z = Random.Range(worldLimits[2], worldLimits[3]);
        return new Vector3(x, 0f, z);
    }
    public void DestroyFood(GameObject food)
    {
        foods.Remove(food);
        Destroy(food);
    }
}
