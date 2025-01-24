using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSync : MonoBehaviour
{
    public float timer = 0;
    [System.Serializable]
    public struct Event
    {
        public string name;
        public float time;
        public GameObject[] objectsToActivate;
        public GameObject[] objectsToDeactivate;
    }
    public Event[] events;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < events.Length; i++)
        {
            //check if the event time is less than the timer
            if (events[i].time <= timer)
            {
                if (events[i].objectsToActivate != null)
                {
                    for (int j = 0; j < events[i].objectsToActivate.Length; j++)
                    {
                        events[i].objectsToActivate[j].SetActive(true);
                    }
                }
                if (events[i].objectsToDeactivate != null)
                {
                    for (int j = 0; j < events[i].objectsToDeactivate.Length; j++)
                    {
                        events[i].objectsToDeactivate[j].SetActive(false);
                    }
                }
            }
        }
        
    }
}
