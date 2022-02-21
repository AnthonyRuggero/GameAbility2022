using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ostacoli : MonoBehaviour
{
    public GameObject pino;
    public GameObject cespuglio;
    public Vector3 pos;
    float cordZ = 0;
    int max = 3000;

    void Update()
    {   
        cordZ += Personaggio.speed;
        GameObject temp;
        for (int i = 0; i <= 2; i++){
            //this random is to see what to spawn (Bush, pine, nothing)
            int random = Random.Range(0, max);

            //if random is between 0 and 7 esculuso it sprouts something (0-4 Bushes, 5-6 Pines)
            //instead between 7 and max it sprays nothing

            if (random < 7){
                if (random >= 0 && random < 5)
                {
                    temp = cespuglio;
                }
                else
                {
                    temp = pino;
                }
                
                //instantiates the spawn of the object
                GameObject spawnObject = (GameObject)Instantiate(temp);

                //in the vector pos we have the initial position of the object
                pos = spawnObject.transform.position;
                float posX = -1f;
                //the lane in which to spawn the object is defined with a random
                int randomX = Random.Range(-1, 2);
                if (randomX == 0)
                {
                    posX = 0.5f;
                }
                else
                {
                    if (randomX == 1f)
                    {
                        posX = 4f;
                    }
                    else
                    {
                        posX = -3.5f;
                    }
                }
                
                //this random defines the z in which to spawn the object which will be between 100 and 1000 blocks in front of the character
                float randomZ = Random.Range(cordZ + 100f, cordZ + 1000f);
                spawnObject.transform.position = pos;
                pos.z = randomZ;
                pos.x = posX;

            }

            //every time the coorZ variable is divisible by a thousand the possibility of spawning nothing decreases and therefore the game becomes more difficult
            if (cordZ % 1000f == 0 && max > 1500)
            {
                max -= 100;
            }
        }
    }
}