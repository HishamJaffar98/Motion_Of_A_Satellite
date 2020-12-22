using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionOfASatellite : MonoBehaviour
{
    [SerializeField] Transform[] routes;
    [SerializeField] float radius = 2f;
    float theta = 64.4f;
    float tParam = 0f;
    Vector3 initialPosition;
    Vector3 objectPosition;
    public bool followCircle = false;
    public bool followEllipse = false;
    public bool followParabola = false;
    public bool followHyperbola=false;
    public float movementSpeed = 0f;
    void Start()
    {
        initialPosition = transform.position;
    }

    
    void Update()
    {
        if(followCircle)
        {
            CircularMotion();
        }
        if(followEllipse)
        {
            EllipticalMotion();
        }
        if(followParabola)
        {
            StartCoroutine(ParabolicMotion());
        }
        if(followHyperbola)
        {
            StartCoroutine(HyperbolicMotion());
        }
    }

    void CircularMotion()
    {
        transform.position = new Vector3(Mathf.Cos(theta) * 10, Mathf.Sin(theta) * 10, transform.position.z);
        theta += Time.deltaTime * movementSpeed;
    }

    void EllipticalMotion()
    {     
        transform.position = new Vector3(Mathf.Cos(theta) * 3*5, Mathf.Sin(theta) * 3*3.5f, transform.position.z);
        theta += Time.deltaTime * movementSpeed;
    }

   IEnumerator ParabolicMotion()
   {
        followParabola = false;
        Vector2 p0 = routes[0].GetChild(0).position;
        Vector2 p1 = routes[0].GetChild(1).position;
        Vector2 p2 = routes[0].GetChild(2).position;
        Vector2 p3 = routes[0].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * ((movementSpeed/11.2f)+2.5f);
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                             3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                             3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                             Mathf.Pow(tParam, 3) * p3;
            transform.position = new Vector3(objectPosition.x, objectPosition.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        followParabola = true;
    }


    IEnumerator HyperbolicMotion()
    {
        followHyperbola = false;
        Vector2 p0 = routes[1].GetChild(0).position;
        Vector2 p1 = routes[1].GetChild(1).position;
        Vector2 p2 = routes[1].GetChild(2).position;
        Vector2 p3 = routes[1].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * ((movementSpeed / 11.2f) + 2.5f);
            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                             3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                             3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                             Mathf.Pow(tParam, 3) * p3;
            transform.position = new Vector3(objectPosition.x, objectPosition.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        followHyperbola = true;
    }

    public void ResetPosition()
    {
        theta = 64.4f;
        SetPathFlagFalse();
        transform.position = initialPosition;
    }

    void SetPathFlagFalse()
    {
        if(followCircle)
        {
            followCircle = false;
        }
        else if(followEllipse)
        {
            followEllipse = false;
        }

        followParabola = false;
        followHyperbola = false;
        StopAllCoroutines();
    }
}
