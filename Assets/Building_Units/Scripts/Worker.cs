using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private float MoveSpeed;
    private Work TaskGiver;
    private GameObject SPileObj;
    private Stockpile SPile;
    private bool HasTask = false;
    private WaitForSeconds SeekTaskDelay = new WaitForSeconds(1f);
    private int WorkType = 0;
    private GameObject WorkTarget = null;
    //Work Type 1
    private bool HasMaterials = false;

    private void Start()
    {
        MoveSpeed = Random.Range(4f, 6f);
        TaskGiver = GameObject.Find("WorkManager").GetComponent<Work>();
        SPileObj = GameObject.Find("Stockpile");
        SPile = SPileObj.GetComponent<Stockpile>();
        StartCoroutine(SeekTask());
    }

    private IEnumerator SeekTask()
    {
        while (true)
        {
            if(HasTask == false)
            {
                TaskGiver.GiveTask(this.gameObject);
            }
            else
            {
                Debug.LogError("HasWork");
            }
            yield return SeekTaskDelay;
        }
    }

    public void GetTask(int Type, GameObject Target)
    {
        WorkType = Type;
        WorkTarget = Target;
        HasTask = true;
    }

    private void Update()
    {
        if(HasTask == true)
        {
            switch (WorkType)
            {
                case 1: TaskType1(); break;
                case 2: break;
                case 3: break;
                case 4: break;
                default: break;
            }
        }
        else
        {
            WonderAround();
        }
    }

    private void TaskType1()
    {
        if (HasMaterials == false)
        {
            if (CloseEnoughTo(SPileObj))
            {
                if (SPile.HasMat() == true)
                {
                    SPile.GetMat();
                    HasMaterials = true;
                }
                else
                {
                    TaskGiver.AddTaskQueue(WorkType, WorkTarget);
                    HasTask = false;
                }
            }
            else
            {
                MoveCloseTo(SPileObj);
            }
        }
        else
        {
            if (CloseEnoughTo(WorkTarget))
            {
                WorkTarget.GetComponent<ToBuild>().AddMat();
                HasMaterials = false;
                HasTask = false;
            }
            else
            {
                MoveCloseTo(WorkTarget);
            }
        }
    } //Get Materials from stockpile, bring to building;

    private bool CloseEnoughTo(GameObject aim)
    {
        if (Vector3.Distance(this.transform.position, aim.transform.position) < 1.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCloseTo(GameObject aim)
    {
        transform.position = Vector3.MoveTowards(transform.position, aim.transform.position, MoveSpeed * Time.deltaTime);
    }

    private void WonderAround()
    {
        Vector3 tempA = transform.position;
        tempA += new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        transform.position = Vector3.MoveTowards(transform.position, tempA, MoveSpeed * 0.25f * Time.deltaTime);
    }
    /*
    private bool IsWorking = false;
    private float MoveSpeed;
    private WaitForSeconds TryGetWorkDelay = new WaitForSeconds(2f);
    private BuildQueue BuildQueueScpt;
    private GameObject WorkObj;
    private ToBuild Work;
    private GameObject Stockpile;
    private bool HaveMaterial = false;

    void Start()
    {
        MoveSpeed = Random.Range(4f, 6f);
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
                //BuildQueueScpt.RemoveTopFromQueue();
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
    */
}
