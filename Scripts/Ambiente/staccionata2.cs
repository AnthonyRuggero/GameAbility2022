using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The translation of fences 1 and 2 takes place in the same way as the mountains
//with the difference in length

public class staccionata2 : MonoBehaviour {
    private float z;
    private float s;
    private float cordZ;
    public Vector3 movimento;

	void Start () {
		z=0;
        cordZ = 100;
        s=90;
	}
	void Update () {
        z += Personaggio.speed;
        if(z>s){
            cordZ += 90;
            movimento.z = cordZ;
            transform.position = movimento;
            z=0;
        }
	}
}
