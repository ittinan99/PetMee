using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIfacingCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dog;
    private Vector3 Pos;
    void Start()
    {
        Pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float ry = Camera.main.transform.position.y - this.transform.position.y;
        float rz = Camera.main.transform.position.z - this.transform.position.z;
        
        float Angle = Mathf.Atan2(ry,rz) * 180 / Mathf.PI;
        this.GetComponent<RectTransform>().eulerAngles = new Vector3(180 - Angle , 0, 0);
        this.transform.position = new Vector3(Dog.transform.position.x, Pos.y, Dog.transform.position.z+1.5f);
    }
}
