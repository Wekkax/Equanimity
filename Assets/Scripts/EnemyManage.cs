using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManage : MonoBehaviour
{
    Animator animator;
    public int enemyhealth = 150;
    public float timeded = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerenter2D(Collider2D col){
            if(col.tag == "Balaka"){
                //enemyhealth -= Instantiate.damage;
                if(enemyhealth <= 0){
                    animator.SetBool("Muere?", true);
                }
            }
        }
    }
}
