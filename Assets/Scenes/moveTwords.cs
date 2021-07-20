using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTwords : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,10f * Time.deltaTime);
    }
}
