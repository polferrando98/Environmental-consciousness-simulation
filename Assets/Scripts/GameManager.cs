using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject humanPrefab;
    public GameObject foodPrefab;
    public List<GameObject> foods;
    public List<GameObject> humans;
    
    public bool activateTime = false;
    public int foodPerDay = 5;

    //Change for actual world limits
    public Vector4 worldLimits;

    // Start is called before the first frame update
    void Start()
    {
        activateTime = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTime)
        {
            GenerateFood();

            /*System.Threading.Thread.Sleep(2000);
            //Human actions
            foreach (Human h in humans)
            {
                h.passDay(foods);
            }*/
            activateTime = false;
        }   
    }
    public void GenerateFood()
    {
        foods = new List<GameObject>(foodPerDay);
        for (int i = 0; i < foodPerDay; i++)
            foods.Add(Instantiate(foodPrefab, GetNewSpawnPosition(), Quaternion.identity));
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
    public void DestroyHuman(GameObject human)
    {
        humans.Remove(human);
        Destroy(human);
    }
}
