using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class CarOne : PlayerController
{
    //ENCAPSULATION
    private float moveSpeed = 150f;
    public float m_moveSpeed {
        get { return moveSpeed; }
    }
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

    //ABSTRACTION && //POLYMORPHISM
    public override void Move(){
        if(Input.GetKey(KeyCode.W)){
            // transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * -m_moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.S)){
            // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * m_moveSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
