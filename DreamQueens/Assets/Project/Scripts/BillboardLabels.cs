using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardLabels : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        var rot = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, TagController.ExtractYaw(rot), Time.deltaTime);
    }
}
