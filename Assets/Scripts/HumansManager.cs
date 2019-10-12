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
    }

    void Start()
    {
        humans = new List<GameObject>();

        gm.cycle_manager.OnCycleMiddle += PassDay;
        
    }
    void PassDay()
    {
        foreach(GameObject human in humans)
        {
            human.GetComponent<Human>().PassDay();
        }
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
            CreateHuman();
        }
    }

    GameObject CreateHuman()
    {
        GameObject new_human = Instantiate(human_prefab,humans_container.transform);
        new_human.transform.position = gm.GetNewSpawnPosition();
        humans.Add(new_human);
        return new_human;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
