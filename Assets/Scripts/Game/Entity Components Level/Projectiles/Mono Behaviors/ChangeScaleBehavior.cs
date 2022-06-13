using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleBehavior : MonoBehaviour
{
    [SerializeField] private Transform colliderTransform;

    [SerializeField] private float expansionTime;
    [SerializeField] private AnimationCurve expansionCurve;
    [SerializeField] private Vector3 expansionDirections;


    void Start()
    {
        StartCoroutine(Expand());
    }



    private IEnumerator Expand()
    {
        var currentTime = 0f;

        while (currentTime < expansionTime)
        {
            colliderTransform.localScale = expansionDirections * expansionCurve.Evaluate(currentTime / expansionTime);
            currentTime += Time.deltaTime;

            yield return null;
        }
    }
}
