using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationIdentifier : MonoBehaviour {


    public int LocIdent;

    public Vector3 volumeSize;
    List<TagController> assocTags = new List<TagController>();



    public void PositionAtLocation(Transform tag)
    {


            tag.transform.localScale *= Random.Range(.4f, 1f);

            tag.transform.localPosition = randLoc();
        bool clean = true;

        for (int i = 0; i < assocTags.Count;i++)
        {



            Bounds curBounds = tag.GetComponent<BoxCollider>().bounds;
            Bounds otherBounds = assocTags[i].transform.GetComponent<BoxCollider>().bounds;

            if (!CheckBounds(curBounds, otherBounds))
            {
                clean = false;

            tag.transform.localPosition = randLoc();
            }
            else
            {
                break;
            }



        }
        if (clean == false)
        {
            tag.position = Vector3.one * 100;
            Debug.Log("failed");
        }


        tag.SetParent(transform);
        assocTags.Add(tag.GetComponent<TagController>());



    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, volumeSize);
    }
        

    Vector3 randLoc()
    {

        Vector3 p = transform.localPosition;
        Vector3 vol = volumeSize / 2;

        Vector2 ranX = new Vector2(p.x - vol.x,
                                   p.x + vol.x);

        Vector2 ranY = new Vector2(p.y - vol.y,
                                   p.y + vol.y);

        Vector2 ranZ = new Vector2(p.z - vol.z,
                                   p.z + vol.z);

        float rX = Random.Range(ranX.x, ranX.y);
        float rY = Random.Range(ranY.x, ranY.y);
        float rZ = Random.Range(ranZ.x, ranZ.y);

        return new Vector3(rX, rY, rZ);
    }

    bool CheckBounds(Bounds cur, Bounds other)
    {
        return !cur.Intersects(other);
    }


}
