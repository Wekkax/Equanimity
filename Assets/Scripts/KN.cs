using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KN : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
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

            rigidBody2D.AddForce(transform.up*900);
            animator.SetBool("Salta?", true);
            animator.SetBool("Grounded", false);
        
        }
        

        if (rigidBody2D.velocity.y < 0) {

            animator.SetBool("Cae?", true);
        }
        else
        {
            animator.SetBool("Cae?", false);
        }


}
/////////////////////////////////////////////////////////////////////////////
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            animator.SetBool("Grounded", true);
            animator.SetBool("Salta?", false);
        }
        else
        {
            animator.SetBool("Grounded", false);
            Debug.Log("Not Grounded");
        }
    }

}
