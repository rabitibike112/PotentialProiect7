using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*1 1-Carry Materials, 2-Build, 3-Bring resources to stockpile, 4-rebuild/repair

public class Work : MonoBehaviour
{
    private struct Task
    {
        int TaskType;  //*1
        GameObject TaskTarget;

        public Task(int Type, GameObject Obj)
        {
            TaskType = Type;
            TaskTarget = Obj;
        }

        public int Type()
        {
            return TaskType;
        }

        public GameObject Target()
        {
            return TaskTarget;
        }
    }

    private Queue<Task> HighTasks = new Queue<Task>();

    public void AddTaskQueue(int Type, GameObject Target)
    {
        HighTasks.Enqueue(new Task(Type, Target));
    }

    public void GiveTask(GameObject Worker)
    {
        Worker tempA = Worker.GetComponent<Worker>();
        if(HighTasks.Count > 0)
        {
            Task tempB = HighTasks.Peek();
            tempA.GetTask(tempB.Type(), tempB.Target());
            HighTasks.Dequeue();
        }
    }
}
