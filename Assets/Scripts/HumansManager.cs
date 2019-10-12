using System.Collections;
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


        gm.cycle_manager.OnCycleMiddle += PassDay;
        
    }
    void PassDay()
    {


        for (int i = 0; i < humans.Count; i++)
        {
            humans[i].GetComponent<Human>().PassDay();
        }

        //humans[0].GetComponent<Human>().PassDay();
    }
    void HandleStart()
    {
        print("Humans spawned");
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
