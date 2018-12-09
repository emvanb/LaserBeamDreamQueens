using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSelector : MonoBehaviour {

    public LayerMask mask;
    TagPopper curPopper;
	// Use this for initialization
	void Start () {
		
	}
	

    private void Update()
    {
        RaycastHit ry = new RaycastHit();
        Debug.DrawRay(transform.position, transform.forward*10f, Color.red);

        if (Physics.SphereCast(transform.position, .1f, transform.forward,out ry))
        {

            if(ry.collider.GetComponent<TagPopper>()==null && curPopper!=null)
            {
                curPopper.Contract();
                curPopper = null;
                return;
            }


            if(curPopper == null)
            {
                curPopper = ry.collider.GetComponent<TagPopper>();
                curPopper.Pop(true);
            }
            else if(curPopper!= ry.collider.GetComponent<TagPopper>())
            {
                curPopper.Contract();

                curPopper = ry.collider.GetComponent<TagPopper>();
                curPopper.Pop(true);

            }
        }
        else if(curPopper!=null)
        {
            curPopper.Contract();
            curPopper = null;

        }
    }
}
