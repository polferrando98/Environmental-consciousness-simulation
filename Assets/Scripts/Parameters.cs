using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Parameters
{
    public static int treeMaxFoodGeneration = 2;
    public static float treeReproductionChance = 0.1f;

    public static float humanAltruism = 0.5f;
    public static float humanMaxEnergy = 14;
    public static float humanMaxDeathChance = 0.5f;
    public static int humanFoodLimit = 2;
    public static float humanReproductionChance = 1;

    public static int startingHumans = 8;

    public static float timeBetweenCycles = 0.5f;
    public static float timeToMove = 2;

    public static int startingTrees = 14;
    public static float wasteGeneratedByEating = 0.01f;
    public static float wasteAbsorbedByTrees = 0.01f;

    public static int daysToSimulate = 10;

    public static int TreeMaxFoodGeneration { get => treeMaxFoodGeneration; set => treeMaxFoodGeneration = value; }
    public static float TreeReproductionChance { get => treeReproductionChance; set => treeReproductionChance = value; }
    public static float HumanAltruism { get => humanAltruism; set => humanAltruism = value; }
    public static float HumanMaxEnergy { get => humanMaxEnergy; set => humanMaxEnergy = value; }
    public static float HumanMaxDeathChance { get => humanMaxDeathChance; set => humanMaxDeathChance = value; }
    public static int HumanFoodLimit { get => humanFoodLimit; set => humanFoodLimit = value; }
    public static float HumanReproductionChance { get => humanReproductionChance; set => humanReproductionChance = value; }
    public static int StartingHumans { get => startingHumans; set => startingHumans = value; }
    public static float TimeBetweenCycles { get => timeBetweenCycles; set => timeBetweenCycles = value; }
    public static float TimeToMove { get => timeToMove; set => timeToMove = value; }
    public static int StartingTrees { get => startingTrees; set => startingTrees = value; }
    public static float WasteGeneratedByEating { get => wasteGeneratedByEating; set => wasteGeneratedByEating = value; }
    public static float WasteAbsorbedByTrees { get => wasteAbsorbedByTrees; set => wasteAbsorbedByTrees = value; }
    public static int DaysToSimulate { get => daysToSimulate; set => daysToSimulate = value; }
}
