using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManager : MonoBehaviour
{
    public delegate void CycleBeginEvent();
    public event CycleBeginEvent OnCycleBegin;

    public delegate void CycleMiddleEvent();
    public event CycleMiddleEvent OnCycleMiddle;

    public delegate void TimeToLookForFoodEvent();
    public event TimeToLookForFoodEvent OnTimeToEat;

    public delegate void CycleEndEvent();
    public event CycleEndEvent OnCycleEnd;

    public delegate void StartEvent();
    public event StartEvent OnStart;

    private float time_between_cycles;
    public float time_to_move;

    bool first_update;
    bool is_mid_cycle;

    HumansManager hm;
    FoodManager fm;
    GameManager gm;
    Window_Graph wg;

    // Start is called before the first frame update
    void Start()
    {
        time_between_cycles= GetComponent<Parameters>().TimeBetweenCycles;
        time_to_move = GetComponent<Parameters>().TimeToMove;
        first_update = true;
        is_mid_cycle = false;
        hm = FindObjectOfType<HumansManager>();
        fm = FindObjectOfType<FoodManager>();
        gm = FindObjectOfType<GameManager>();
        wg = FindObjectOfType<Window_Graph>();
    }

    private void Update()
    {
        if (first_update)
        {
            OnStart?.Invoke();
            StartCoroutine(CycleUpdate());
            first_update = false;
        }

        if (is_mid_cycle)
        {
            is_mid_cycle = false;
            OnCycleMiddle?.Invoke();
            
        }

    }

    IEnumerator CycleUpdate()
    {
        // suspend execution for 5 seconds
        for (int i=0; i< gm.parameters.DaysToSimulate; i++)
        {
            yield return new WaitForSeconds(time_between_cycles);
            OnCycleBegin?.Invoke();
            
            yield return new WaitForSeconds(time_between_cycles);

            is_mid_cycle = true;

            yield return new WaitForSeconds(time_to_move);

            Variables.updateHumanData(hm.humans.Count);
            Variables.updateTreeData(fm.trees.Count);
            Variables.updateContaminationData(gm.contamination);

            if(wg)
                wg.renderPlot();

            OnTimeToEat?.Invoke();


            yield return new WaitForSeconds(time_between_cycles);


           // print(Variables.printData());


            OnCycleEnd?.Invoke();
            
        }


    }

}
