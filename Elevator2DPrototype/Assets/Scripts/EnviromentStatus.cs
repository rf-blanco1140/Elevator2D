using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentStatus : MonoBehaviour
{
    private bool isWindy;
    [SerializeField] List<Directions> levelDirections;
    [SerializeField] List<float> timeStamps;
    private Directions currentWindDirection;
    private float timeLoopCounter;

    private void Start()
    {
        isWindy = false;
        currentWindDirection = Directions.Nulo;
        timeLoopCounter = 0;
        StartCoroutine(ExecuteLevelDirections());
    }

    private void FixedUpdate()
    {
        /**if(timeLoopCounter<5)
        {
            timeLoopCounter += Time.deltaTime;
        }
        else
        {
            SelectRandomDirection();
            timeLoopCounter = 0;
        }*/
    }

    public bool GetIsWindy()
    {
        return isWindy;
    }

    public Directions GetWindDirection()
    {
        return currentWindDirection;
    }

    public void SelectRandomDirection()
    {
        currentWindDirection = (Directions)Random.Range(0,4);
    }

    IEnumerator ExecuteLevelDirections()
    {
        for(int i=0;i<timeStamps.Count;i++)
        {
            currentWindDirection = levelDirections[i];
            yield return new WaitForSeconds(timeStamps[i]);
        }
    } 
}
