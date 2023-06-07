using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KN : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2D;
    CapsuleCollider2D collider;
    GameObject corazón;
    float caetime;
    bool sonidot;
    float sufretime;
    float blacktime;
    float intert;
    float timertitulo;
    bool muriendo;
    bool transss;
    bool enboss;
    public int Khalihealth = 150;

    public AudioSource pasos;
    public AudioSource ataque;
    public AudioSource trans;
    public AudioSource salto;
    public AudioSource queja;
    public AudioSource cura;
    public AudioSource aqua;

    public AudioClip músicaboss;

    public Sprite vidafull;
    public Sprite vidamid;
    public Sprite vidapoca;

    public Sprite sobrecargafull;
    public Sprite sobrecargamid;
    public Sprite sobrecargalow;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        sonidot = false;
        transss = false;
        enboss = false;
        intert = -1;
        sufretime = Time.time;
        blacktime = Time.time;
        timertitulo = Time.time;
        corazón = GameObject.Find("vida");
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////////////////////////Correr y moverse hacia delante

        if (Input.GetAxis("Horizontal") != 0f){
 
            animator.SetBool("Corriendo?", true);
            transform.Translate(17f * Time.deltaTime, 0f, 0f); 
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


        if (animator.GetBool("Salta?")){
            animator.SetBool("Salta?", true);

            if(!salto.isPlaying){
                salto.Play();
            }
        }else{
            salto.Stop();
        }

        if (animator.GetBool("Sobrecarga?")){

            if(!sonidot){
                trans.Play();
                sonidot = true;
            }
        }

        if (animator.GetBool("Elige vuelta a intermedia")){

            if(sonidot){
                trans.Play();
                sonidot = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////Transformación a intermedia

        if(Input.GetKey("e") && !transss){
            animator.SetBool("Transformación intermedia?", true);
            transss = true;
            intert = Time.time;
        }

        /////////////////////////////////////////////////////////////////////////////Transformación sobrecarga

        if(Time.time - intert > 60f && intert > -1){
            animator.SetBool("Sobrecarga?", true);
        }

        if(Khalihealth <= 0){
                Debug.Log("buuuu");
                GameObject.Find("Blackout").GetComponent<Image>().color = new Color(0,0,0,255);
                if(!muriendo){
                    muriendo = true;
                    blacktime = Time.time;
                    AudioListener.volume = 0;
                }
                if(Time.time - blacktime > 3f){
                    GameObject.Find("Blackout").GetComponent<Image>().color = new Color(0,0,0,0);
                    AudioListener.volume = 1;
                    muriendo = false;
                    Khalihealth = 150;
                    transform.position = new Vector2(5.21f, -9.47f);
                }
            }

        if(intert > -1){
            if(Time.time - intert < 20){
                GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargalow;
            }else if(Time.time - intert < 40){
                GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargamid;
            }else{
                GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargafull;
            }


            /*switch(Time.time - intert){
            case 20f:
            GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargalow;
            break;
            
            case 40f:
            GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargamid;
            break;
            
            case 58f:
            GameObject.Find("BARRADESOBRECARGA").GetComponent<Image>().sprite = sobrecargafull;
            break;*/
        }
    
        

        //////////////////////////////////////////////////////////////////////////Bajada vida

        switch(Khalihealth){
            case 150:
            GameObject.Find("BARRAVIDA").GetComponent<Image>().sprite = vidafull;
            break;
            
            case 100:
            GameObject.Find("BARRAVIDA").GetComponent<Image>().sprite = vidamid;
            break;
            
            case 50:
            GameObject.Find("BARRAVIDA").GetComponent<Image>().sprite = vidapoca;
            break;
        }

        ///////////////////////////////////////////////////////////////////////////Entrada a sala Boss

        if(enboss == true){
            
            if(Time.time - timertitulo < 0.5f){
                GameObject.Find("titulo boss final").GetComponent<Image>().color = new Color(1f, 1f, 1f, (Time.time - timertitulo)/0.5f);
            }else{
                if(Time.time - timertitulo < 6f && Time.time - timertitulo > 5f){
                    GameObject.Find("titulo boss final").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f -(Time.time - timertitulo -5f));
                }
            }
            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    ////////////////////////////////////////////////////////////////////////////
    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.tag == "Ground"){
            animator.SetBool("Grounded", true);
            animator.SetBool("Salta?", false);
        }
    } 

    //////////////////////////////////////////////////////////////////////////Colliders y muerte/Sala Boss/Ganar vida
    void OnTriggerStay2D(Collider2D colli){
            
            if(Time.time - sufretime > 1f){
                switch(colli.tag){
                case "Enemy": 
                Khalihealth -= 50;
                Debug.Log("Ayayaya");
                queja.Play();
                sufretime = Time.time;
                break;
                /////
                case "Duro":
                Khalihealth -= 150;
                Debug.Log("Ayayaya");
                queja.Play();
                break;
                }
            }

            if(colli.tag == "Boss" && !enboss){
                enboss = true;
                timertitulo = Time.time;

                GameObject.Find("Música").GetComponent<AudioSource>().clip = músicaboss;
                GameObject.Find("Música").GetComponent<AudioSource>().Play();
                aqua.Play();
            }

            if(colli.tag == "Vida"){
                Khalihealth += 50;
                cura.Play();
                Destroy(corazón);
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


