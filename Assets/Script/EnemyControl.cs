using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float introTime = 2;
    float totalTime = 10;
     Animator anim;
     public  SpriteRenderer drawA;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        //drawA = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(introTime>=0)
        {
            introTime -= Time.deltaTime; 
        }
        else 
        {
            anim.enabled = true;
            
        }

        if(totalTime >=0)
        {
            if(introTime<=0)
                totalTime-=Time.deltaTime;
        }
        else
        {
            anim.SetInteger("Fire", 1);
        }

        if(Input.GetKeyDown(KeyCode.W)&& drawA.sprite.name == "Western_7" )
        {
            anim.SetInteger("Fire", -1);
        }
        else if(Input.GetKeyDown(KeyCode.W)&& drawA.sprite.name == "Western_6" )
        {
            anim.SetInteger("Fire", 1);
        }
        
    }
}
