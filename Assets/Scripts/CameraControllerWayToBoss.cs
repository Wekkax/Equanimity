using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerWayToBoss : MonoBehaviour
{
    public Transform target; //este es el objeto que vamos a seguir,o sea el jugador

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (target.position.x,target.position.y+5 , transform.position.z);
    }
}
