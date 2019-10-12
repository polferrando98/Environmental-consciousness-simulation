using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Graph
{
    public static List<float> contamination = new List<float>();
    public static List<int> humans = new List<int>();
    public static List<int> trees = new List<int>();

    public static void updateContaminationData(float cont)
    {
        contamination.Add(cont);
    }
    public static void updateHumanData(int h)
    {
        humans.Add(h);
    }
    public static void updateTreeData(int t)
    {
        trees.Add(t);
    }
    public static void printData()
    {
        /* if (humans[humans.Count - 1] == 0 || trees[trees.Count - 1] == 0)
         {
             print(String.Join("; ", humans));
             print(String.Join("; ", trees));
             print(String.Join("; ", contamination));

    }*/
}

}
