using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInicio : MonoBehaviour
{
    
   // public Vector3 desiredPosition = new Vector3(147.7f, -49.2f, 0f);


    // Start is called before the first frame update
    void Start()
    {}

    private void OnTriggerEnter2D(Collider2D collision)
        {
  
        if (collision.gameObject.tag == "Player") //una funcion que solo se cumple si quien entra en el collider tiene tag de Player
        {
            //cambio de escena
            SceneManager.LoadScene("SampleScene 1");

          //transform.position = desiredPosition;
           
        //transform.position = new Vector3(147.7f, -49.2f, 0f);
                 }
            
        }
  }
       

       



