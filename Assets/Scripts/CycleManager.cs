using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleManager : MonoBehaviour
{
    public delegate void CycleBeginEvent();
    public event CycleBeginEvent OnCycleBegin;

    public delegate void CycleEndEvent();
    public event CycleEndEvent OnCycleEnd;

    [SerializeField]
    private int time_between_cycles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CycleUpdate());
    }

    IEnumerator CycleUpdate()
    {
        // suspend execution for 5 seconds
        while (true)
        {
            print("new_cycle");

            OnCycleBegin?.Invoke();
            yield return new WaitForSeconds(time_between_cycles);
            OnCycleEnd?.Invoke();
        }


    }
}
