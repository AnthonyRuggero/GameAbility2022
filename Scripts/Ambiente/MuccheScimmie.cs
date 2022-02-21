using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuccheScimmie : MonoBehaviour {
    private float z;
    private float s;

    private float cordZ;
    public Vector3 movimento;


	void Start () {
		z=0;
        cordZ = movimento.z;
        s=1000;
	}
	void Update () {
        z += 0.1f;
        if(z>s){
            cordZ += 1000;
            movimento.z = cordZ;
            transform.position = movimento;
            z=0;
        }
	}
}