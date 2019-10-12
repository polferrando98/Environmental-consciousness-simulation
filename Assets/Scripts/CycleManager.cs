using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManager : MonoBehaviour
{
    public delegate void CycleBeginEvent();
    public event CycleBeginEvent OnCycleBegin;

    public delegate void CycleMiddleEvent();
    public event CycleBeginEvent OnCycleMiddle;

    public delegate void CycleEndEvent();
    public event CycleEndEvent OnCycleEnd;

    public delegate void StartEvent();
    public event StartEvent OnStart;

    [SerializeField]
    private int time_between_cycles;

    // Start is called before the first frame update
    void Start()
    {
        OnStart?.Invoke();
        StartCoroutine(CycleUpdate());
    }

    IEnumerator CycleUpdate()
    {
        // suspend execution for 5 seconds
        while (true)
        {
            print("new_cycle");

            OnCycleBegin?.Invoke();
            OnCycleMiddle?.Invoke();
            yield return new WaitForSeconds(time_between_cycles);
            OnCycleEnd?.Invoke();
        }


    }
}
