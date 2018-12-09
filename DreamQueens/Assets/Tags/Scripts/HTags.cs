using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

abstract public class HTags : MonoBehaviour
{

    public TagParams tagParams;


    //[Header("Body")]
    //public string UserName;
    //public string Contents;
    //public int TagIndex;

    //[Header("Identifiers")]
    //public int Location;
    //public int HashIdent;

    [Header("Components")]
    public TextMeshProUGUI contentText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI indexText;
    public TextMeshProUGUI timeText;







}

public struct TagParams
{
    public string uName;
    public string content;
    public int tIndex;
    public int location;
    public int hashIndent;
    public string timeStamp;
}
