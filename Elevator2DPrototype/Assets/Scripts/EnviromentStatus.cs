using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentStatus : MonoBehaviour
{
    private bool isWindy;
    public enum Direction { Nulo, North, East, South, West};
    [SerializeField] List<Direction> levelDirections;
    [SerializeField] List<float> timeStamps;
    private Direction currentWindDirection;
    private float timeLoopCounter;

    private void Start()
    {
        isWindy = false;
        currentWindDirection = Direction.East;
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
            selectRandomDirection();
            timeLoopCounter = 0;
        }*/
    }

    public bool GetIsWindy()
    {
        return isWindy;
    }

    public Direction GetWindDirection()
    {
        return currentWindDirection;
    }

    public void selectRandomDirection()
    {
        currentWindDirection = (Direction)Random.Range(0,3);
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
