using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        {
            transform.position = new Vector2 (0,-11);
            GetComponent < Animator > ().Play("Transformación sobrecarga", -1, 0.0f);
        }
    }
}