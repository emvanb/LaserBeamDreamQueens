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


        GetComponent<ObjectFloat>().StartFloat();

    }
}
