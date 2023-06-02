using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torvi : MonoBehaviour
{
    public Animator animatorK;
    Animator animator;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objetivo = Target.position + new Vector3(-2*((Target.localRotation.y == 1)?-1:1),5,0);
        transform.position = Vector3.Lerp(transform.position,objetivo,0.05f);

        Quaternion characterRotation = transform.localRotation;
        if ((objetivo-Target.position).x > 0)
        {
            characterRotation.y = 180f;
        }else{
            characterRotation.y = 0f;
        }
        transform.localRotation = characterRotation;

        animator.SetBool("Transformación aire", animatorK.GetBool("Transformación intermedia?"));
    }
}
