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
        Work TempA = GameObject.Find("WorkManager").GetComponent<Work>();
        for(int i =0;i< MatNeeded; i++)
        {
            TempA.AddTaskQueue(1, this.gameObject);
        }

        BuildMat = transform.GetComponent<Renderer>().material;
        Color tempB = BuildMat.color;
        tempB.a = 0.1f;
        BuildMat.color = tempB;
    }

    void Update()
    {
        if(MatHave >= MatNeeded)
        {
            transform.GetComponent<Renderer>().material = FinishedMat;
            Destroy(this.GetComponent<ToBuild>());
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
