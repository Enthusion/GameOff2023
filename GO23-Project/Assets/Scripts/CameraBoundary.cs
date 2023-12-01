using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    [SerializeField]
    private bool constrainX;
    [SerializeField]
    private bool constrainY;
    private float xLimit = 8.9f;
    private float yLimit = 5.0f;
    
    private CameraScript mainCam;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = FindObjectOfType<Camera>();
        mainCam = cam?.GetComponent<CameraScript>();
        if(mainCam == null){
            Debug.Log("No camera found");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
