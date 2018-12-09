using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour {

    Vector3 stPos;
    [SerializeField] 
    float offset;
    [SerializeField] 
    float speed;


    public void StartFloat()
    {
        stPos = transform.localPosition;
        int ind = Random.Range(0, 2);
        if(ind == 1)
        {
            StartCoroutine(FloatUp());
        }
        else
        {
            StartCoroutine(FloatDown());
        }


    }

    IEnumerator FloatUp()
    {
        float nS = speed * Random.Range(.5f, 1.1f);
        Vector3 dest = stPos +(Vector3.up * offset);


        while (Vector3.Distance(transform.localPosition, dest) > .01f)
        {
            transform.localPosition += Vector3.up * nS * Time.deltaTime;

            transform.localScale -= Vector3.one * nS/4 * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(FloatDown());


    }
    IEnumerator FloatDown()
    {
        Vector3 dest = stPos - (Vector3.up * offset);

        float nS = speed * Random.Range(.5f, 1.1f);

        while (Vector3.Distance(transform.localPosition, dest) > .01f)
        {
            transform.localPosition -= Vector3.up * nS * Time.deltaTime;
            transform.localScale += Vector3.one * nS/4 * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(FloatUp());

    }
}
