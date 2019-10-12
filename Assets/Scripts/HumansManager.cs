using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HumansManager : MonoBehaviour
{
    private GameManager gm;

    public List<GameObject> humans;

    public GameObject human_prefab;

    public GameObject humans_container;
    public int starting_humans = 10;
    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();

        gm.cycle_manager.OnStart += HandleStart;

        humans = new List<GameObject>();
    }

    void Start()
    {


        gm.cycle_manager.OnCycleMiddle += ProcessDay;
        
    }
    void ProcessDay()
    {
        int nHumans = humans.Count;

        List<GameObject> newHumans = new List<GameObject>();
        for (int i = 0; i < humans.Count; i++)
        {
            GameObject newHuman = humans[i].GetComponent<Human>().ProcessDay();
            //If it reproduced we store the new human
            if (newHuman)
            {
                newHumans.Add(newHuman);
                newHuman.transform.SetParent(humans_container.transform);
            }
        }
        //Kill dead humans
        humans = humans.Where(human => !human.GetComponent<Human>().Kill()).ToList();
        print("DAY X: Started with " + nHumans+"humans, "+ (nHumans - humans.Count) + " died, "+ newHumans.Count + " born");
        //Store new humans in the same vector as before
        humans.AddRange(newHumans);
        
        
    }
    void HandleStart()
    {
        GenerateAllHumans();
    }
    int NHumansToSpawn()
    {
        return starting_humans;
    }
    void GenerateAllHumans()
    {
        int humans_to_spawn = NHumansToSpawn();

        for (int i = 0; i < humans_to_spawn; i++)
        {
            humans.Add(
            CreateHuman());
        }
    }

    GameObject CreateHuman()
    {
        GameObject new_human = Instantiate(human_prefab,humans_container.transform);
        new_human.transform.position = gm.GetNewSpawnPosition();
        return new_human;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
