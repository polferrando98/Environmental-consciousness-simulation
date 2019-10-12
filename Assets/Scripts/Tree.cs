using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Entity
{
    GameManager gm;
    [SerializeField] private float foodDropRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override GameObject ProcessDay()
    {
        GenFood();
        return null;
        
    }
    void GenFood()
    {
        float x = Random.Range(-foodDropRange, foodDropRange);
        float z = Random.Range(-foodDropRange, foodDropRange);
        //gm.foods.Add(Instantiate
    }
}
