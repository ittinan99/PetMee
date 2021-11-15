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
            Vector3 mosPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mosPos);


            Debug.Log(mosPos);
            Debug.Log("Click");
            if(Physics.Raycast(ray,out hit)&&hit.transform.gameObject.CompareTag("Pet")){
                Debug.DrawRay(ray.origin, ray.direction *100, Color.red);
                if(normalCam.gameObject.activeInHierarchy == true){
                    normalCam.gameObject.SetActive(false);
                    lookAtCam.gameObject.SetActive(true);
                    lookAtCam.Follow = hit.collider.transform;
                    lookAtCam.LookAt = hit.collider.transform;
                    hit.transform.gameObject.GetComponent<PetBehavior>().IsCamLook = true;
                    Debug.Log("normal to lookat");
                }else{
                    normalCam.gameObject.SetActive(true);
                    lookAtCam.gameObject.SetActive(false);
                    hit.transform.gameObject.GetComponent<PetBehavior>().IsCamLook = false;
                    Debug.Log("ookat to normal");
                }
            }

        }
    }
}
