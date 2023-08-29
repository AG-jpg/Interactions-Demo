using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int levelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    public int Level { get; set; }

    private float ActualExp;
    private float ReqExpNextlevel;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        ReqExpNextlevel = expBase;
        UpdateExpBar();
    }

    public void AddExp(float expObt)
    {
        if(expObt > 0f)
        {
            float expRestNextLevel = ReqExpNextlevel - ActualExp;
            if(expObt >= expRestNextLevel)
            {
                expObt -= expRestNextLevel;
                UpdateLevel();
                AddExp(expObt);
            }
            else
            {
                ActualExp += expObt;
                if(ActualExp == ReqExpNextlevel)
                {
                    UpdateLevel();
                }
            }
        }

        UpdateExpBar();
    }

    private void UpdateLevel()
    {
        if(Level < levelMax)
        {
            Level++;
            ActualExp = 0f;
            ReqExpNextlevel *= valorIncremental;
        }
    }

    private void UpdateExpBar()
    {
        UIManager.Instance.UpdateExpPlayer(ActualExp, ReqExpNextlevel);
    }
}
