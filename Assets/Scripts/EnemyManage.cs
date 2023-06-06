using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManage : MonoBehaviour
{
    Animator animator;
    public int enemyhealth = 150;
    public float timeded = 0.6f;
    public AudioSource sufre;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Auch");
            switch(col.tag){
                case "Balaka": 
                enemyhealth -= 50;
                
                break;
            }
            
            if(enemyhealth <= 0){
                animator.SetBool("Muere?", true);
                }
            
            //////////////Sonido
                sufre.Play();
    }    
}
