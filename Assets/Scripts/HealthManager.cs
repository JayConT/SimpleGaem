using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject bar1, bar2, bar3;
    void Start()
    {
        bar1.SetActive(true);
        bar2.SetActive(true);
        bar3.SetActive(true);
    }

    public void damaged1()
    {
        bar3.SetActive(false);
    }

    public void damaged2()
    {
        bar2.SetActive(false);
    }

    public void damaged3()
    {
        bar1.SetActive(false);
    }
}
