using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{



    protected Transform X_Camera;
    protected Transform X_Parent;

    protected Vector3 Rotations;
    protected float distanceCamera;

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float OrbitSpeed = 10f;
    public float ScrollSpeed = 6f;

    public bool cameraDisabled = true;


    void Start()
    {
        this.X_Camera = this.transform;
        this.X_Parent = this.transform;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
            cameraDisabled = false;
        }else{
            cameraDisabled = true;
        }

    
    if(!cameraDisabled){
        if(Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") !=0){
            Rotations.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            Rotations.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0f){
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

            ScrollAmount *= (this.distanceCamera *0.3f);

            this.distanceCamera += ScrollAmount * -1f;

            this.distanceCamera = Mathf.Clamp(this.distanceCamera, 1.5f, 100f);
        }




    }

    Quaternion QT = Quaternion.Euler(Rotations.y, Rotations.x, 0);
    this.X_Parent.rotation = Quaternion.Lerp(this.X_Parent.rotation, QT, Time.deltaTime * OrbitSpeed);

    if(this.X_Camera.localPosition.z != this.distanceCamera * -1f){
        this.X_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.X_Camera.localPosition.z, this.distanceCamera * -1f, Time.deltaTime * ScrollSpeed));
    }

        
    }
}
