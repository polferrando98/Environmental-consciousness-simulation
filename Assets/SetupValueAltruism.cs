using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetupValueAltruism : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = gm.parameters.HumanAltruism;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
