using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Camera player1Cam;
    [SerializeField] Camera player2Cam;

    // Start is called before the first frame update
    void Start()
    {
        goMainCam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goIndiCam()
    {
        player1Cam.gameObject.SetActive(true);
        player2Cam.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
    }

    public void goMainCam()
    {
        player1Cam.gameObject.SetActive(false);
        player2Cam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
    }
}
