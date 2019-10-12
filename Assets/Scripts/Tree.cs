using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Entity
{
    public GameManager gm;
    public float reproductionRange = 5f;
    public float foodDropRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PassDay()
    {
        GenFood();
        
    }
    void GenFood()
    {
        float x = Random.Range(-foodDropRange, foodDropRange);
        float z = Random.Range(-foodDropRange, foodDropRange);
        //gm.foods.Add(Instantiate
    }

    protected override GameObject Reproduce()
    {
        float x = Random.Range(-reproductionRange, reproductionRange);
        float z = Random.Range(-reproductionRange, reproductionRange);
        return Instantiate(gameObject, new Vector3(x, 0, z), Quaternion.identity);
    }
}
