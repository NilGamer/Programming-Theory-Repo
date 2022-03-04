using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] List<Transform> targets;
    public Vector3 offset;
    public float smoothTime = 0.5f;
    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimit = 50f;

    private GameManager gameManager;

    private Camera cam;

    private void Start() {
        cam = GetComponent<Camera>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        Zoom();
    }

    void Zoom()
    {
        if(GetZDistance() > 30f || GetGreatestDistance() > 30f){
            gameManager.goIndiCam();
        }else{
            float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimit);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        }
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        //SmoothDamp allows you to make movement smooth
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i<targets.Count; i++)
        {
            //increase bound size as targets added
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    float GetZDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i<targets.Count; i++)
        {
            //increase bound size as targets added
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.z;
    }

    Vector3 GetCenterPoint()
    {
        //creating a bound to 1st target
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i<targets.Count; i++)
        {
            //increase bound size as targets added
            bounds.Encapsulate(targets[i].position);
        }

    //return center of bounds
        return bounds.center;
    }
}
