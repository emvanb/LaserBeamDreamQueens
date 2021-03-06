﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : HTags {

    private TagPopper tagPopper;
    private Quaternion myOffset;
    public float speed;

    private void Start()
    {
        tagPopper = GetComponent<TagPopper>();
        myOffset = Quaternion.AngleAxis(Random.RandomRange(-30f, 30f), Vector3.up);

        transform.localRotation = GetTargetRotation();
    }

    private Quaternion GetTargetRotation()
    {
        var rot = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        rot = ExtractYaw(rot);
        if (tagPopper.isSelected)
        {
            return rot;
        }
        return rot * myOffset;
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, GetTargetRotation(), Time.deltaTime);
    }

    public static Quaternion ExtractYaw(Quaternion q)
    {
        q.x = 0;
        q.z = 0;
        float mag = Mathf.Sqrt(q.w * q.w + q.y * q.y);
        q.w /= mag;
        q.y /= mag;

        return q;
    }

    public void SetUpTag()
    {
        contentText.text = tagParams.content;
        nameText.text = tagParams.uName;
        indexText.text = tagParams.tIndex.ToString();
        timeText.text = tagParams.timeStamp;


        GetComponentInChildren<ObjectFloat>().StartFloat();

    }

    public void SetColor(Color col)
    {
        mesh.material.color = col;
        mesh.material.SetColor("_Emission", col);
        float H, S, V;
        Color.RGBToHSV(col, out H,out  S,out V);
        contentText.color = Color.HSVToRGB(H, S / 1.6f, V / 1.6f);
        nameText.color = Color.HSVToRGB(H, S / 4, V / 4);
        var main = parts.main;
        main.startColor = col;
        

    }

    public void SetState(bool isActive)
    {
        if(isActive)
        {
            parts.Play();
        }
        else
        {
            parts.Stop();
        }
    }
}
