using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        // playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected bool checkGameOver()
    {
        if(transform.rotation.z > 40f || transform.rotation.z < -40f || transform.rotation.x > 100f || transform.rotation.x < -100f){
            return true;
        } 
        return false;
    }

    public virtual void Move()
    {
        //override move
    }
}
