using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stockpile : MonoBehaviour
{
    [SerializeField]
    private int Materials = 100;

    public int GetMat()
    {
        Materials -= 1;
        return 1;
    }

    public void GiveMat()
    {
        Materials += 1;
    }
}
