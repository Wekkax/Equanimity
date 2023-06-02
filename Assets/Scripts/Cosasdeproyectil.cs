using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosasdeproyectil : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right*15f*Time.deltaTime;
    }
}
