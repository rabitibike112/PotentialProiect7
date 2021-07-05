using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBuild : MonoBehaviour
{
    [SerializeField]
    private int MatNeeded = 10;
    private int MatHave = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(MatHave >= MatNeeded)
        {
            Destroy(this.GetComponent<ToBuild>());
        }
    }

    public bool NeedMat()
    {
        if(MatNeeded > MatHave)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddMat()
    {
        MatHave += 1;
    }
}
