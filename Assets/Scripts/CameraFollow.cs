using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // public float FollowSpeed = 2f;
    // public Transform target;
    // public float yOffset = 1f;

    public Vector2 delta = new Vector2(0.0f, 0.0f);
    [SerializeField]
    Vector2 velocidad = new Vector2(1f, 3f);
    

    // public float speedx = 3;
    // public float speedy = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
            // transform.Translate = (Input.GetAxis("Horizontal") * speedx, 0, Input.GetAxis("Vertical") * speedy);

            delta.x = Input.GetAxis ("Horizontal") * velocidad.x * Time.deltaTime  ;
            delta.y = Input.GetAxis ("Vertical") * velocidad.y * Time.deltaTime ; 
            transform.Translate(delta);

    }
        // Vector3 newPos = new Vector3(target.position.x, target.position.y + y.yOffset, -10f);
        // transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*time);
    }

