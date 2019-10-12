using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManager : MonoBehaviour
{
    public delegate void CycleBeginEvent();
    public event CycleBeginEvent OnCycleBegin;

    public delegate void CycleMiddleEvent();
    public event CycleMiddleEvent OnCycleMiddle;

    public delegate void CycleEndEvent();
    public event CycleEndEvent OnCycleEnd;

    public delegate void StartEvent();
    public event StartEvent OnStart;

    [SerializeField]
    private float time_between_cycles;

    bool first_update;
    bool is_mid_cycle;

    // Start is called before the first frame update
    void Start()
    {

        first_update = true;
        is_mid_cycle = false;
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
        while (true)
        {
            print("new_cycle");

            yield return new WaitForSeconds(time_between_cycles);
            OnCycleBegin?.Invoke();
            
            yield return new WaitForSeconds(time_between_cycles);

            is_mid_cycle = true;
            OnCycleEnd?.Invoke();
        }


    }

}
