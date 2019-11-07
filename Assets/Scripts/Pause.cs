using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   	public bool paused;

    void Start()
    {
        paused = false;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        	paused = !paused;
        }

        if(paused)
        {
        	Time.timeScale = 0;
        }else if(!paused)
        {
        	Time.timeScale = 1;
        }
    }
}
