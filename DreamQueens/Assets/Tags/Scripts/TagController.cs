using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagController : HTags {




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
