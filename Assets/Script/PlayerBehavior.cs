using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    public AudioSource musicSource; 

    public AudioClip gunFire;

    public AudioClip gunFireL;

    public AudioClip winSound;

    public AudioClip loseSound;

    public TextMeshProUGUI start;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI winL;
    //public TextMeshProUGUI timeText;

    float totalTime = 10;
    float introTime = 2;
    int winOrLos = -1;
    bool fireOpen;
    private SpriteRenderer drawR;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        drawR = gameObject.GetComponent<SpriteRenderer>();
        timer.enabled = false;
        winL.enabled = false;
        anim.enabled= false;
        fireOpen = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        //drawing = 
        if(introTime>=0)
        {
            introTime -= Time.deltaTime; 
        }
        else 
        {
            start.enabled = false;
            timer.enabled = true;
            anim.enabled = true;
            fireOpen = true;
            
        }
        if(fireOpen==true)
        {
            if(timer.enabled == true )
            {
                if(totalTime>=0 && winOrLos==-1)
                {
                    timer.text = "Timer till death: " + totalTime.ToString("f0");
                    totalTime -= Time.deltaTime;
                }
                else if(totalTime <=0)
                {
                    anim.SetInteger("Win", -1);
                    winOrLos = 0;
                    WinLM(winOrLos);
                }
            }
        //Loss Condition here as an else statement
            if(drawR.sprite.name == "Western_7" && Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("Win", 1);
                winOrLos = 1;
                WinLM(winOrLos);
            }
            else if(drawR.sprite.name == "Western_6" && Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("Win", -1);
                winOrLos = 0;
                WinLM(winOrLos);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();       
            }
        }
    }
    public void  WinLM (int winOrLos)
    {
        if( winOrLos==1)
        {
            winL.enabled= true;
        }
        if(winOrLos==0)
        {
            winL.enabled = true;
            winL.text= "You have been defeated";
        }
    }

  
}
