using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPopper : MonoBehaviour {


    public float offset;
    public float speed;
    Vector3 stSc;

    bool expanded;

	// Use this for initialization
	void Start () {
        stSc = transform.localScale;
		
	}
    public void Pop(bool popOn)
    {
        
        if(!popOn)
        {
            transform.localScale = stSc / offset;
        }
        else if(popOn && !expanded)
        {
            StartCoroutine(PopOn());
        }
    }

    IEnumerator PopOn()
    {
        transform.localScale = stSc;
        Vector3 dest = stSc * offset*1.5f;
        while(Vector3.Distance(transform.localScale, dest)>.1f)
        {
            transform.localScale += Vector3.one*speed * Time.deltaTime;
            yield return null;
        }
        while (Vector3.Distance(transform.localScale, stSc * offset) > .1f)
        {
            transform.localScale -= Vector3.one * speed *2* Time.deltaTime;
            yield return null;
        }

        transform.localScale = stSc * offset;
        expanded = true;
        GetComponent<TagController>().SetState(true);
    }

    public void Contract()
    {
        StopAllCoroutines();
        transform.localScale = stSc;
        expanded = false;
        GetComponent<TagController>().SetState(false);
    }
}
