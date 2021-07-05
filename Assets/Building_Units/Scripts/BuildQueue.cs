using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildQueue : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Buildings;
    private bool BuildMenu = false;
    private Queue<GameObject> BuildOrder = new Queue<GameObject>();

    void Update()
    {
        if (BuildMenu == false && Input.GetKeyDown(KeyCode.B))
        {
            BuildMenu = true;
        }
        else if (BuildMenu == true && Input.GetKeyDown(KeyCode.B))
        {
            BuildMenu = false;
        }

        if(BuildMenu == true && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 tempA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
            BuildOrder.Enqueue(Instantiate(Buildings[0], tempA, Quaternion.identity));
            BuildMenu = false;
        }
    }
    public GameObject QueueTop()
    {
        if(BuildOrder.Count > 0)
        {
            return BuildOrder.Peek();
        }
        else
        {
            return null;
        }
    }

    public void RemoveTopFromQueue()
    {
        BuildOrder.Dequeue();
    }
}
