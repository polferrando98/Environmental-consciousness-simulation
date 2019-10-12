using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Vector2 reproductionRange = new Vector2(2f, 8f);
    [SerializeField] protected bool dead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //maybe not abstract
    public abstract GameObject ProcessDay();
    protected GameObject Reproduce()
    {
        
        float x = Random.Range(reproductionRange[0], reproductionRange[1]);
        float z = Random.Range(reproductionRange[0], reproductionRange[1]);
        return Instantiate(gameObject, new Vector3(x, 0, z), Quaternion.identity);
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
