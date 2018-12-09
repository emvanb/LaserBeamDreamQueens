using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPopper : MonoBehaviour
{


    public float offset;
    public float speed;
    Vector3 stSc;

    public bool isSelected;

    public AudioClip[] sfx;
    AudioSource src;

    // Use this for initialization
    void Start()
    {
        stSc = transform.localScale;
        src = GetComponent<AudioSource>();

    }

    public void Pop(bool popOn)
    {

        if (!popOn)
        {
            //transform.localScale = stSc / offset;
        }
        else if (popOn && !isSelected)
        {
            StartCoroutine(PopOn());
        }
    }

    IEnumerator PopOn()
    {
        //transform.localScale = stSc;
        //Vector3 dest = stSc * offset*1.1f;
        //while(Vector3.Distance(transform.localScale, dest)>.1f)
        //{
        //    transform.localScale += Vector3.one*speed * Time.deltaTime;
        //    yield return null;
        //}
        //while (Vector3.Distance(transform.localScale, stSc * offset) > .1f)
        //{
        //    transform.localScale -= Vector3.one * speed *2* Time.deltaTime;
        //    yield return null;
        //}

        //src.PlayOneShot(sfx[0]);
        //transform.localScale = stSc * offset;
        isSelected = true;
        GetComponent<TagController>().SetState(true);
        yield return null;
    }

    public void Contract()
    {
        //StopAllCoroutines();
        //transform.localScale = stSc;
        isSelected = false;
        GetComponent<TagController>().SetState(false);
    }
}