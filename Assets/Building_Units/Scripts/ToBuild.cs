using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBuild : MonoBehaviour
{
    [SerializeField]
    private int MatNeeded = 10;
    private int MatHave = 0;
    private Material BuildMat;
    [SerializeField]
    private Material FinishedMat;

    void Start()
    {
        BuildMat = transform.GetComponent<Renderer>().material;
        Color tempA = BuildMat.color;
        tempA.a = 0.1f;
        BuildMat.color = tempA;
    }

    void Update()
    {
        if(MatHave >= MatNeeded)
        {
            transform.GetComponent<Renderer>().material = FinishedMat;
            GameObject.Find("BuildQueueManager").GetComponent<BuildQueue>().RemoveTopFromQueue();
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

    private void UpdateColor()
    {
        Color TempA = BuildMat.color;
        TempA.a = MatHave / 10f;
        BuildMat.color = TempA;
    }

    public void AddMat()
    {
        MatHave += 1;
        UpdateColor();
    }
}
