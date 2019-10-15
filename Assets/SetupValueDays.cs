using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupValueDays : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = gm.parameters.DaysToSimulate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
