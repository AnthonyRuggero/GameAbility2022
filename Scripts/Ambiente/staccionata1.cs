using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class staccionata1 : MonoBehaviour {
    private float z;
    private float s;
    private float cordZ;
    public Vector3 movimento;

	void Start () {
		z=0;
        cordZ = 10;
        s=90;
	}
	void Update () {
        z += 0.1f;
        if(z>s){
            cordZ += 90;
            movimento.z = cordZ;
            transform.position = movimento;
            z=0;
        }
	}
}
