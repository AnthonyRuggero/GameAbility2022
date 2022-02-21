using UnityEngine;
using System.Collections;

public class  Telecamera: MonoBehaviour {
 private Vector3 cameraLocation;

 void Start () {
     //define the starting position of the camera
     cameraLocation.x = 0;
     cameraLocation.y = 15;
     cameraLocation.z = -30;
 }
 
 // Update is called once per frame
 void Update () {
    //increase the z to allow the camera to follow the character
    cameraLocation.z += Personaggio.speed;
    transform.position = cameraLocation ;
 }
}
