using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class CarTwo : PlayerController
{
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float rotateSpeed = 50f;
    bool gameOver;
    bool win = false;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            Move();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("base")){
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("finish"))
        {
            win = true;
        }
    }

    public override void Move(){
        if(Input.GetKey(KeyCode.UpArrow)){
            // transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
