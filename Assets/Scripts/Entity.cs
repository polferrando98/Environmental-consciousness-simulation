using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Vector2 reproductionRange = new Vector2(2f, 8f);
    [SerializeField] protected bool dead = false;
    [SerializeField] protected int daysLived = 0;
    [SerializeField] protected float reproductionChance = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void UpdateReproductionChance()
    {
        //Posar aqui dependencia amb contamination
    }
    public abstract GameObject ProcessDay();
    protected GameObject Reproduce(GameObject prefab)
    {
        UpdateReproductionChance();
        float diceRoll = Random.Range(0f, 1f);
        if (diceRoll < reproductionChance)
            return Utils.SpawnObjectAroundObject(transform.position, prefab, reproductionRange[0], reproductionRange[1], gameObject.transform.parent, true);
        else
            return null;
        
    }
    public bool Kill()
    {
        if (dead)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
