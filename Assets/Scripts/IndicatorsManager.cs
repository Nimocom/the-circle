using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class IndicatorsManager : MonoBehaviour
{
    public static IndicatorsManager inst;

    [SerializeField] Transform[] indicators;
    [SerializeField] Transform[] wayPoints;

    [SerializeField] float movingSpeed;

    Dictionary<int, int> indicatorWaypoints;

    void Awake()
    {
        inst = this;

        indicatorWaypoints = new Dictionary<int, int>();
        indicatorWaypoints.Add(0, 0);
    }

    public void MoveIndicator(int steps, int indicatorIndex)
    {
        StopAllCoroutines();
        StartCoroutine(LerpSphere(indicatorIndex, steps));
    }

    IEnumerator LerpSphere(int indicatorIndex, int steps)
    {
        Transform sphere = indicators[indicatorIndex];

        int currentPoint = indicatorWaypoints[indicatorIndex];

        currentPoint++;

        if (currentPoint == 40)
            currentPoint = 0;

        Vector3 targetPosition = wayPoints[currentPoint].position;

        for (int i = 0; i < indicatorWaypoints.Count; i++)
        {
            if (indicatorWaypoints.ElementAt(i).Value == currentPoint)
                targetPosition = new Vector3(targetPosition.x, targetPosition.y + 0.015f, targetPosition.z);
        }

        while (steps > 0) 
        {
            sphere.position = Vector3.MoveTowards(sphere.position, targetPosition, movingSpeed * Time.deltaTime);

            if (sphere.position == targetPosition)
            {
                steps--;
                currentPoint++;

                if (currentPoint == 40)
                    currentPoint = 0;

                targetPosition = wayPoints[currentPoint].position;

                for (int i = 0; i < indicatorWaypoints.Count; i++)
                {
                    if (indicatorWaypoints.ElementAt(i).Value == currentPoint)
                        targetPosition = new Vector3(targetPosition.x, targetPosition.y + 0.015f, targetPosition.z);
                }
            }

            yield return null;
        } 

        indicatorWaypoints[indicatorIndex] = currentPoint-1;
        DiceManager.inst.diceThrown = false;
    }
}
