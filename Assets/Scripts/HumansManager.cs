using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumansManager : MonoBehaviour
{
    private GameManager gm;

    public List<GameObject> humans;

    public GameObject uman_prefav;

    public GameObject humans_container;

    // Start is called before the first frame update
    void Start()
    {
        humans = new List<GameObject>();
        gm = FindObjectOfType<GameManager>();

        gm.cycle_manager.OnCycleBegin += HandleCycleBegin;
        gm.cycle_manager.OnCycleEnd += HandleCycleEnd;
    }

    void HandleCycleBegin()
    {
        GenerateAllHumans();
    }

    void HandleCycleEnd()
    {

    }

    void GenerateAllHumans()
    {
        int humans_to_spawn = Random.Range(1, 10);

        for (int i = 0; i < humans_to_spawn; i++)
        {
            CreateHuman();
        }
    }

    public Vector3 GetNewSpawnPosition()
    {
        float x = Random.Range(0,100);
        float z = Random.Range(0, 100);
        return new Vector3(x, 0f, z);
    }

    GameObject CreateHuman()
    {
        GameObject new_human = Instantiate(uman_prefav,humans_container.transform);
        new_human.transform.position = GetNewSpawnPosition();
        humans.Add(new_human);
        return new_human;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
