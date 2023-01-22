using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    AudioSource playerEffects;
    public AudioSource musicSource; 

    public AudioClip gunFire;

    public AudioClip gunFireL;

    public AudioClip winSound;

    public AudioClip loseSound;
    public AudioClip intro;
    public AudioClip song;

    public TextMeshProUGUI start;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI winL;
    //public TextMeshProUGUI timeText;

    float totalTime = 10;
    float introTime = 2;
    int winOrLos = -1;
    bool fireOpen;
    bool timerDone = true;
    bool soundDone = false;
    bool timeL = false;
    private SpriteRenderer drawR;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        drawR = gameObject.GetComponent<SpriteRenderer>();
        playerEffects = GetComponent<AudioSource>();
        timer.enabled = false;
        winL.enabled = false;
        anim.enabled= false;
        fireOpen = false;
        musicSource.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        //drawing = 
        if(introTime>=0)
        {
            introTime -= Time.deltaTime; 
            if(soundDone ==false)
            {
                playerEffects.PlayOneShot(intro);
                soundDone = true;
            }
        }
        else if(introTime <=0)
        {
            start.enabled = false;
            timer.enabled = true;
            anim.enabled = true;
            fireOpen = true;
            if(timerDone==true)
            {
                musicSource.enabled = true;
                timerDone = false;
            }
            
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
                else if(totalTime <=0 && timeL == false)
                {
                    //Debug.Log("HERE WATCH YOUR EARS");
                    timeL = true;
                    playerEffects.volume = .5f;
                    playerEffects.PlayOneShot(gunFireL);
                    anim.SetInteger("Win", -1);
                    winOrLos = 0;
                    WinLM(winOrLos);
                }
            }
        //Loss Condition here as an else statement
            if(drawR.sprite.name == "Western_7" && Input.GetKeyDown(KeyCode.W) && winOrLos==-1)
            {
                playerEffects.volume = .5f;
                playerEffects.PlayOneShot(gunFire);
                anim.SetInteger("Win", 1);
                winOrLos = 1;
                WinLM(winOrLos);
            }
            else if(drawR.sprite.name == "Western_6" && Input.GetKeyDown(KeyCode.W) && winOrLos ==-1)
            {
                playerEffects.volume = .5f;
                playerEffects.PlayOneShot(gunFireL);
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
            musicSource.enabled = false;
            playerEffects.PlayOneShot(winSound);
            winL.enabled= true;

        }
        if(winOrLos==0)
        {
            musicSource.enabled = false;
            playerEffects.PlayOneShot(loseSound);
            winL.enabled = true;
            winL.text= "You have been defeated";
        }
    }

  
}
