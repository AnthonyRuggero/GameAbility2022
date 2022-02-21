using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the ground being always the same, it is moved simultaneously and at the same 
//speed as the character

public class Terreno : MonoBehaviour {
    private float z;
    public Vector3 movimento;

	void Start () {
		z=0;
	}
	
	void Update () {
        z += Personaggio.speed;
        movimento.z = z;
        transform.position = movimento;
	}
}