using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour {

    public List<LocationIdentifier> Locations;
    public GameObject tagPrefab;
    List<TagController> curTags;

    Dictionary<int, Color> hashColor = new Dictionary<int, Color>();

    public int tempSpawnAmount;

    public static TagManager tMan;

    private void Awake()
    {
        tMan = this;
    }

    // Use this for initialization
    void Start () {


        for (int i = 0; i < tempSpawnAmount; i++)
        {
            TagParams nParam = new TagParams();
            nParam.location = Random.Range(0, Locations.Count);
            nParam.hashIndent = Random.Range(0, 6);
            nParam.tIndex = 0;
            nParam.content = "This is a test. You're valid";
            nParam.timeStamp = "12/01 1:40pm";
            nParam.uName = "Anonymouseeee";

            PopulateTags(nParam);

        }



        
		
	}
	
    public void PopulateTags(TagParams tParams)
    {
        Color nCol = new Color();


        if(!hashColor.ContainsKey(tParams.hashIndent))
        {
            nCol = Random.ColorHSV(0,1,1,1,1,1);
            hashColor.Add(tParams.hashIndent, nCol);
        }
        else
        {
            hashColor.TryGetValue(tParams.hashIndent, out nCol);
        }


        //



        GameObject nTag = Instantiate(tagPrefab);

        TagController tg = nTag.GetComponent<TagController>();
        tg.tagParams = tParams;

        curLoc(tParams.location).PositionAtLocation(tg.transform);
        tg.SetUpTag();
        tg.SetColor(nCol);

    }





    LocationIdentifier curLoc(int index)
    {
        LocationIdentifier cLoc = new LocationIdentifier();
        for (int i = 0; i < Locations.Count; i++)
        {
            if (Locations[i].LocIdent == index)
            {
                cLoc = Locations[i];
            }
        }
        return cLoc;

    }



}
