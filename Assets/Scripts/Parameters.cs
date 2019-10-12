using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public int treeMaxFoodGeneration;
    public float treeReproductionChance;

    public float humanAltruism;
    public float humanMaxEnergy;
    public float humanMaxDeathChance;
    public int humanFoodLimit;
    public float humanReproductionChance;

    public int startingHumans;

    public float timeBetweenCycles;
    public float timeToMove;

    public int startingTrees;
    public float wasteGeneratedByEating;
    public float wasteAbsorbedByTrees;

    public int daysToSimulate;
}
