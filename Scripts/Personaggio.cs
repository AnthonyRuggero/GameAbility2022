using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personaggio : MonoBehaviour
{
    public Rigidbody rb;
    private Animator anim;
    public Vector3 movimento;

    private int durataSalto;
    private float positionY;
    public bool dead;
    private float polsX = 0;
    private float polsY = 0;
    public Vector2 coor;
    public string c;
    public PlayGame gameLose;

    private int delay = 0;

    public static float speed = 0.1f;


    void Start()
    {   //I start the character in the middle lane on the ground
        movimento.y = 0;
        movimento.x = 0;
        transform.position = movimento;
        //this variable will be used for the jump time
        positionY = 0;
        //and death initialises it as false
        dead = false;

    }

    public void walkingFarward()
    {   
        //this function is used to have the coordinates of the wrist
        conversioneCoor();
        //wonder if the character is alive
        if (!dead)
        {   
            //the character continuously moves forward with an easily modifiable speed
            movimento.z += speed;
            transform.position = movimento;
            //I do the various conditions to understand if the user wants to go left / right / center / jump
            if (coor.x >= -5)
            {
                movimento.x = -4f;
                transform.position = movimento;
            }
            if (coor.x <= -11)
            {
                    movimento.x = 4f;
                    transform.position = movimento;
             }
            if (coor.x > -11 && coor.x < -5)
            {
                    movimento.x = 0;
                    transform.position = movimento;
            }
            //I check if the character is jumping
            if (positionY > 0)
             {  
                //this code is used to make the jump last for a certain period
                if (positionY == durataSalto)
                {   
                    //after passing the jump duration, the character is brought back to the ground
                    positionY = 0;
                    movimento.y = 0;
                    transform.position = movimento;
                    delay = 50;
                }
                else
                {
                        positionY++;
                }
            }
            if (coor.y >= 5.5f)
            {   
                //the delay is used to avoid flying and therefore the character must stay a certain period (delay) on the ground before being able to jump consecutively
                if(delay == 0){
                if (positionY == 0)
                {
                    movimento.y = 4f;
                    transform.position = movimento;
                    positionY++;
                }
                }else{
                    delay--;
                }
             }
            }
        }




    
    //Questa funzione verifica constantemente se il personaggio collide con un osacolo
    void OnTriggerEnter(Collider collision)
    {   
        c = collision.gameObject.tag;
        if (c == "pino")
        {
            dead = true;
            gameLose.gameOver();
        }
        if (c == "cespuglio")
        {
            dead = true;
            gameLose.gameOver();
        }

    }

    //questa è una funzione di UDPrecever(Soket) cheprende le coordinate del polso
    public void conversioneCoor()
    {   
        //coordinate virtuali
        polsX = FindObjectOfType<UDPReceiver>().getxPolsoDx();
        polsY = FindObjectOfType<UDPReceiver>().getyPolsoDx();

        //coordinate reali
        coor.x = (-(DimensionCords.GAMEPLAYSCREENX / 2) + (polsX * DimensionCords.GAMEPLAYSCREENX) / DimensionCords.CAMERASCREENX);
        coor.y = (DimensionCords.GAMEPLAYSCREENY / 2) + (polsY * DimensionCords.GAMEPLAYSCREENY) / DimensionCords.CAMERASCREENY;
    }
}

