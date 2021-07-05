using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private bool IsWorking = false;
    private float MoveSpeed = 5f;
    private WaitForSeconds TryGetWorkDelay = new WaitForSeconds(2f);
    private BuildQueue BuildQueueScpt;
    private GameObject WorkObj;
    private ToBuild Work;
    private GameObject Stockpile;
    private bool HaveMaterial = false;

    void Start()
    {
        BuildQueueScpt = GameObject.Find("BuildQueueManager").GetComponent<BuildQueue>();
        Stockpile = GameObject.Find("Stockpile").gameObject;
        StartCoroutine(SeekWork());
    }


    void Update()
    {
        if(IsWorking == true)
        {
            if(Work !=null && Work.NeedMat() == true)
            {
                if(HaveMaterial == false)
                {
                    if (CloseEnoughTo(Stockpile))
                    {
                        Stockpile.GetComponent<Stockpile>().GetMat();
                        HaveMaterial = true;
                    }
                    else
                    {
                        MoveCloseTo(Stockpile);
                    }
                }
                else
                {
                    if (CloseEnoughTo(WorkObj))
                    {
                        Work.AddMat();
                        HaveMaterial = false;
                    }
                    else
                    {
                        MoveCloseTo(WorkObj);
                    }
                }
            }
            else
            {
                BuildQueueScpt.RemoveTopFromQueue();
                IsWorking = false;
            }
        }
    }

    private void MoveCloseTo(GameObject aim)
    {
        transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, MoveSpeed * Time.deltaTime);
    }

    private bool CloseEnoughTo(GameObject aim)
    {
        if(Vector3.Distance(this.transform.position,aim.transform.position) < 1.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator SeekWork()
    {
        while (true)
        {
            if(IsWorking == false)
            {
                GameObject tempA = BuildQueueScpt.QueueTop();
                if(tempA != null)
                {
                    WorkObj = tempA;
                    Work = tempA.GetComponent<ToBuild>();
                    IsWorking = true;
                }
            }
            else
            {
                Debug.LogError("Is Working!");
            }
            yield return TryGetWorkDelay;
        }
    }
}
