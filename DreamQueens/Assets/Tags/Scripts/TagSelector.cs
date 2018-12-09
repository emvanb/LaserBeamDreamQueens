using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSelector : MonoBehaviour {

    public LayerMask mask;
    TagPopper curPopper;
    Transform curs;
	// Use this for initialization
	void Start () {
        curs = transform.GetChild(0);
		
	}
	
    private void ClearCurrentPopper()
    {
        curPopper.Contract();
        curPopper = null;
    }

    private void Update()
    {
        RaycastHit ry = new RaycastHit();
        Debug.DrawRay(transform.position, transform.forward*10f, Color.red);

        // Youre looking at something
        if (Physics.SphereCast(transform.position, .1f, transform.forward,out ry))
        {
            var newPopper = ry.collider.GetComponent<TagPopper>();
            curs.position = ry.point;
            // Youre looking at a new thing that is not a Popper
            if (newPopper == null)
            {
                if(curPopper != null)
                {
                    ClearCurrentPopper();
                }
            }

            // Youre looking at a popper
            else
            {
                // It's a unique popper
                if(curPopper != newPopper)
                {
                    if(curPopper != null)
                    {
                        ClearCurrentPopper();
                    }

                    curPopper = newPopper;
                    curPopper.Pop(true);
                }
            }
        }

        else
        {
            if (curPopper != null)
            {
                ClearCurrentPopper();
            }

            curs.position = transform.forward * 3f;
        }
    }
}
