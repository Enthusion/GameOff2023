using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;

    // Update is called once per frame
    void Update()
    {
        if(target){
            transform.position = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, transform.position.z);
        }
    }
}
