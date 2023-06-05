using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KN : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2D;
    CapsuleCollider2D collider;
    float caetime;

    public AudioSource pasos;
    public AudioSource ataque;
    public AudioSource trans;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////////////////////////Correr y moverse hacia delante

        if (Input.GetAxis("Horizontal") != 0f){
 
            animator.SetBool("Corriendo?", true);
            transform.Translate(20f * Time.deltaTime, 0f, 0f); 
        }else{
            animator.SetBool("Corriendo?", false);
        }

        ///////////////////////////////////////////////////////////Rotar al otro lado cuando se mueve

        Quaternion characterRotation = transform.localRotation;
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            characterRotation.y = 180f;
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            characterRotation.y = 0f;
        }
        transform.localRotation = characterRotation;

        ////////////////////////////////////////////////////////////Salto

        if (Input.GetKey("space") && animator.GetBool("Grounded") && !animator.GetBool("Salta?") && (animator.GetBool("Transformación intermedia?") || animator.GetBool("Sobrecarga?"))) {

            rigidBody2D.AddForce(transform.up*0.12f);
            animator.SetBool("Salta?", true);
            animator.SetBool("Grounded", false);
        
        }
        

        if (rigidBody2D.velocity.y < 0) {
            
            if(caetime == -1){
                caetime = Time.time;
            }else{
                if(Time.time - caetime > 0.1f){
                    animator.SetBool("Cae?", true);
                    animator.SetBool("Grounded", false);   
            }
            }
            
        }
        else
        {
            animator.SetBool("Cae?", false);
            animator.SetBool("Grounded", true);
            caetime = -1;
        }


        ////////////////////////////////////////////////////////////////////////////////////Sonido

        if (animator.GetBool("Corriendo?") && !animator.GetBool("Sobrecarga?") && !animator.GetBool("Salta?") && !animator.GetBool("Cae?")){
            animator.SetBool("Corriendo?", true);
            
            if(!pasos.isPlaying){
                pasos.Play();
            }
        }else{
            pasos.Pause();
        }

        if (animator.GetBool("Ataca?")){
            animator.SetBool("Ataca?", true);

            if(!ataque.isPlaying){
                ataque.Play();
            }
        }else{
            ataque.Stop();
        }

        /*if (animator.GetBool("Sobrecarga?") || animator.GetBool("Elige vuelta a intermedia")){
            animator.SetBool("Sobrecarga?", true);
            animator.SetBool("Elige vuelta a intermedia", true);

            if(!trans.isPlaying){
                trans.Play();
            }
        }else{
            trans.Stop();
        }*/



        }


void OnCollisionEnter2D(Collision2D col){
    if(col.collider.tag == "Ground"){
        animator.SetBool("Grounded", true);
        animator.SetBool("Salta?", false);
    }
        
}
}




//////////////////////////////////////////////////////////////////////////////////////////////FALLOS
/*void FixedUpdate(){
    RaycastHit2D hit;
    hit = Physics2D.CapsuleCast(collider.bounds.center,collider.size,collider.direction,collider.transform.localRotation.z,new Vector2(0,-1f),Mathf.Epsilon);
    if(hit.collider.tag == "Ground"){
            animator.SetBool("Grounded", true);
            animator.SetBool("Salta?", false);
            Debug.Log(hit.collider.gameObject.name);
    }else{
            animator.SetBool("Grounded", false);
            Debug.Log("Not Grounded");
    }
    
}*/
/////////////////////////////////////////////////////////////////////////////
    /*void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Loquesea");
            animator.SetBool("Grounded", true);
            animator.SetBool("Salta?", false);
        }
        else
        {
            animator.SetBool("Grounded", false);
            Debug.Log("Not Grounded");
        }
    }*/


