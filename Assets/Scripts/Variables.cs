using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables
{
    public static int daysPassed = 0;
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
    public static string printData()
    {
       // if (humans.Count != 0 && trees.Count != 0)
       // {
            string humansS = string.Join("; ", humans);
            string treesS = string.Join("; ", trees);
            string contS = string.Join("; ", contamination);
            return humansS + "|\n" + treesS + "|\n" + contS;
      //  }
      //  return "";
}

}
