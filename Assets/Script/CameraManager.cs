using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public LayerMask layerPet;
    RaycastHit hit;

    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera lookAtCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,1000,layerPet)){
                if(normalCam.gameObject.activeInHierarchy == true){
                    normalCam.gameObject.SetActive(false);
                    lookAtCam.gameObject.SetActive(true);
                    lookAtCam.Follow = hit.collider.transform;
                    lookAtCam.LookAt = hit.collider.transform;
                }else{
                    normalCam.gameObject.SetActive(true);
                    lookAtCam.gameObject.SetActive(false);
                    
                }
            }

        }
    }
}
