using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSelector : MonoBehaviour {

    public LayerMask mask;
    TagPopper curPopper;
	// Use this for initialization
	void Start () {
		
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

        // You're not hitting anything now
        else if(curPopper!=null)
        {
            ClearCurrentPopper();
        }
    }
}
