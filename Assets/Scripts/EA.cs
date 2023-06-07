using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA : MonoBehaviour {
    float p;
    Vector2 Startpos;
    int contador;
    int mm;
    float timerataque;
    bool haso;
    Animator animator;
    CapsuleCollider2D col;

    public AudioSource ataca;
    public AudioSource cmuere;
    // Start is called before the first frame update
    void Start()
    {
        p = Time.time;
        contador = 0;
        timerataque = Time.time;
        Startpos = transform.position;
        animator = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();
        haso = false;
    }

    // Update is called once per frame
    void Update()
    {
       //transform.Translate(Input.GetAxis("Horizontal")* 15f * Time.deltaTime, 0f, 0f); 
       if(!animator.GetBool("Muere?")){
        if (Time.time - p >= 0.25f){
        if(contador != 2){
            float inter = (Time.time - p - 0.25f)/1.625f;
            transform.position = Vector2.Lerp(Startpos, Startpos + (Vector2)transform.right * -3, inter);
        
            if(inter >= 1f){
                p = Time.time;
                Startpos = transform.position;
                contador++;
                mm++;
            }
            
            timerataque = Time.time;

        }else{
            if(!animator.GetBool("Ataca?")){
                  timerataque = Time.time;
                  p = Time.time;
            }
            animator.SetBool("Ataca?", true);
            
        }
       }
       if (Time.time - timerataque >= 1.375){
        animator.SetBool("Ataca?", false);
        contador = 0;
        p = Time.time;
        timerataque = Time.time;
       }

       ////////////////////////////////////////////////////De lado a lado

       if(mm == 4f){
        Quaternion characterRotation = transform.localRotation;
        if(characterRotation.y > 0.9f){
            characterRotation.y = 0f;
        }else{
            characterRotation.y = 180f;
        }
        transform.localRotation = characterRotation;
        mm = 0;
       }

       //////////////////////////////////////////////////Sonido

        /*if (animator.GetBool("Muere?")){
            Debug.Log("suena esto?");

            if(!cmuere.isPlaying){
                cmuere.Play();
            }
        }else{
                cmuere.Stop();
                Debug.Log("y esto?");
        }*/

        if (animator.GetBool("Ataca?")){

            if(!ataca.isPlaying){
                ataca.Play();
            }
        }else{
            ataca.Stop();
        }
       }else{
        
        if(!haso){
            cmuere.Play();
            haso = true;
                }
       }
       
    }
}
