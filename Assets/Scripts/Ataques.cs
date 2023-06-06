using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    Animator animator;
    GameObject pepo;
    GameObject pepi;
    GameObject pepu;
    bool atacando;
    bool ulteando;
    float t;
    float cooldown;
    public Transform pposition;
    public GameObject proyectil1;
    public GameObject proyectil2;
    public GameObject proyectil3;
    public AudioSource ulti;

    public static int damage;
    public int damageRef = 50;

    // Start is called before the first frame update
    void Start()
    {
        t = Time.time;
        animator = GetComponent<Animator>();
        atacando = false;

        damage = damageRef;
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////////////////////Intermedia
        if ((Input.GetMouseButtonDown(0)) && (animator.GetBool("Transformación intermedia?") && !(animator.GetBool("Sobrecarga?"))) && !atacando){

            pepo = Instantiate(proyectil1, pposition.position + new Vector3 (0,0,-0.1f), pposition.rotation);
            animator.SetBool("Ataca?", true);
            atacando = true;
            t = Time.time;
        }

        //////////////////////////////////////////////////////////////Sobrecarga normal

        if ((Input.GetMouseButtonDown(0)) && (animator.GetBool("Sobrecarga?")) && !atacando){

            pepi = Instantiate(proyectil2, pposition.position + new Vector3 (0,0,-0.1f), pposition.rotation);
            animator.SetBool("Ataca?", true);
            atacando = true;
            t = Time.time;
        }

        //////////////////////////////////////////////////////////////Sobrecarga ulti

        if (Input.GetKey("r") && (animator.GetBool("Sobrecarga?")) && Time.time - cooldown > 7f){

            pepu = Instantiate(proyectil3, pposition.position + new Vector3 (0,0,-0.1f), pposition.rotation);
            animator.SetBool("Ataca?", true);
            ulteando = true;
            cooldown = Time.time;
        }

        if(Time.time - cooldown > 0.6f && ulteando){
            animator.SetBool("Ataca?", false);
            ulteando = false;
        }

        if (Time.time - t > 0.8f && atacando){
            animator.SetBool("Ataca?", false);
            atacando = false;
            Destroy(pepo);
            Destroy(pepi);
        }

        if (Time.time - cooldown > 1.2f){
            Destroy(pepu);
        }

        if (!atacando && !ulteando){
            animator.SetBool("Ataca?", false);
        }

        //////////////////////////////////////////////////////Daño del ataque



        /////////////////////////////////////////////////////Sonido Ulti

        if (Input.GetKey("r") && animator.GetBool("Sobrecarga?")){
            //animator.SetBool("Ataca?", true);

            if(!ulti.isPlaying){
                ulti.Play();
            }
        }else{
            ulti.Stop();
        }

        
    }
}
