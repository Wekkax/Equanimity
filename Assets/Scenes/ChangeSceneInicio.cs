using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInicio : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {


    }

    

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player") //una funcion que solo se cumple si quien entra en el collider tiene tag de Player
        {
            //cambio de escena
            SceneManager.LoadScene("SampleScene 1");
        }
    }

}
