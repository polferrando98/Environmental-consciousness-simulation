using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField]  int treeMaxFoodGeneration = 2;
    [SerializeField]  float treeReproductionChance = 0.1f;

    [SerializeField]  float humanAltruism;
    [SerializeField]  float humanMaxEnergy = 14;
    [SerializeField]  float humanMaxDeathChance = 0.5f;
    [SerializeField]  int humanFoodLimit = 2;
    [SerializeField]  float humanReproductionChance = 1;

    [SerializeField]  int startingHumans = 8;

    [SerializeField]  float timeBetweenCycles = 0.5f;
    [SerializeField]  float timeToMove = 2;

    [SerializeField]  int startingTrees = 14;
    [SerializeField]  float wasteGeneratedByEating = 0.01f;
    [SerializeField]  float wasteAbsorbedByTrees = 0.01f;

    [SerializeField]  int daysToSimulate;

    public  int TreeMaxFoodGeneration { get => treeMaxFoodGeneration; set => treeMaxFoodGeneration = value; }
    public  float TreeReproductionChance { get => treeReproductionChance; set => treeReproductionChance = value; }
    public  float HumanAltruism {
        get => humanAltruism;
        set => humanAltruism = value;
 
    }
    public  float HumanMaxEnergy { get => humanMaxEnergy; set => humanMaxEnergy = value; }
    public  float HumanMaxDeathChance { get => humanMaxDeathChance; set => humanMaxDeathChance = value; }
    public  int HumanFoodLimit { get => humanFoodLimit; set => humanFoodLimit = value; }
    public  float HumanReproductionChance { get => humanReproductionChance; set => humanReproductionChance = value; }
    public  int StartingHumans { get => startingHumans; set => startingHumans = value; }
    public  float TimeBetweenCycles { get => timeBetweenCycles; set => timeBetweenCycles = value; }
    public  float TimeToMove { get => timeToMove; set => timeToMove = value; }
    public  int StartingTrees { get => startingTrees; set => startingTrees = value; }
    public  float WasteGeneratedByEating { get => wasteGeneratedByEating; set => wasteGeneratedByEating = value; }
    public  float WasteAbsorbedByTrees { get => wasteAbsorbedByTrees; set => wasteAbsorbedByTrees = value; }
    public  int DaysToSimulate { get => daysToSimulate; set => daysToSimulate = value; }

    public void Awake()
    {
        DaysToSimulate = PlayerPrefs.GetInt("DaysToSimulate");
        //HumanAltruism = PlayerPrefs.GetFloat("HumanAltruism");
    }
    public void DaysToSimulateFloat(float value)
    {
        DaysToSimulate = (int)value;
        PlayerPrefs.SetInt("DaysToSimulate", DaysToSimulate);
    }
    public void SetAltruism(float value)
    {
        HumanAltruism = value;
        PlayerPrefs.SetFloat("HumanAltruism", HumanAltruism);
    }
}
