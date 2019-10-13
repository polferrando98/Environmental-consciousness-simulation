using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderText : MonoBehaviour
{
   [SerializeField] string parameterName;
    Text text;
    [SerializeField] bool isInt = false;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        
        gameObject.GetComponentInParent<Slider>().onValueChanged.AddListener(OnSliderUpdate);
        text.text = parameterName + ": " +GetComponentInParent<Slider>().value;
    }
    void OnSliderUpdate(float value)
    {
        if(!isInt)
         text.text = parameterName+": "+value.ToString();
        else
            text.text = parameterName + ": " + ((int)value).ToString();
    }
}
