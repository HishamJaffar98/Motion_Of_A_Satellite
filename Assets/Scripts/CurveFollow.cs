using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollow : MonoBehaviour
{
    [SerializeField] Transform[] routes;
    int routeToGo = 0;
    float tParam = 0f;
    Vector3 objectPosition;
    [SerializeField] float speedModifier = 0.5f;
    bool coroutineAllowed = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coroutineAllowed)
        {
            StartCoroutine(FollowRoute(routeToGo));
        }
    }
    
    IEnumerator FollowRoute(int routeNumber)
    {
        coroutineAllowed = false;
        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam<1)
        {
            tParam += Time.deltaTime * speedModifier;
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                             3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                             3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                             Mathf.Pow(tParam, 3) * p3;
            transform.position = new Vector3(objectPosition.x,objectPosition.y,transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        coroutineAllowed = true;
    }
}
