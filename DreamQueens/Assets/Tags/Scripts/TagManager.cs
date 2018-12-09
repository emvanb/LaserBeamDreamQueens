using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour {

    public List<LocationIdentifier> Locations;
    public GameObject tagPrefab;
    public List<GameObject> emojiPrefabs;
    List<TagController> curTags = new List<TagController>();

    Dictionary<string, Color> hashColor = new Dictionary<string, Color>();

    public int tempSpawnAmount;

    public static TagManager tMan;

    private void Awake()
    {
        tMan = this;
    }

    // Use this for initialization
    void Start () {


        //for (int i = 0; i < tempSpawnAmount; i++)
        //{
        //    TagParams nParam = new TagParams();
        //    nParam.location = Random.Range(0, Locations.Count);
        //    nParam.hashIndent = Random.Range(0, 6);
        //    nParam.tIndex = 0;
        //    nParam.content = "This is a test. You're valid";
        //    nParam.timeStamp = "12/01 1:40pm";
        //    nParam.uName = "Anonymouseeee";

        //    PopulateTags(nParam);

        //}



        
		
	}
	
    public void PopulateTags(TagParams tParams)
    {
        if(tParams.emojiIndex>0)
        {
            CreateEmoji(tParams);
            return;
        }



        Color nCol = new Color();

        if(!hashColor.ContainsKey(tParams.hashTag))
        {
            nCol = Random.ColorHSV(0,1,1,1,1,1);
            hashColor.Add(tParams.hashTag, nCol);
        }
        else
        {
            hashColor.TryGetValue(tParams.hashTag, out nCol);
        }


        //


        tParams.tIndex = curTags.Count;
        GameObject nTag = Instantiate(tagPrefab);

        TagController tg = nTag.GetComponent<TagController>();
        curTags.Add(tg);
        tg.tagParams = tParams;

        curLoc(tParams.location).PositionAtLocation(tg.transform);
        tg.SetUpTag();
        tg.SetColor(nCol);

    }

    void CreateEmoji(TagParams tParams)
    {

        GameObject nTag = Instantiate(emojiPrefabs[tParams.emojiIndex-1]);

        TagController tg = nTag.GetComponent<TagController>();
        tg.tagParams = tParams;

        curLoc(tParams.location).PositionAtLocation(tg.transform);
        tg.SetUpTag();

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
