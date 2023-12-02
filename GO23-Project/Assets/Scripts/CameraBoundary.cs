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
        if (mainCam == null)
        {
            Debug.Log("No camera found");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float camX = mainCam.transform.position.x;
        float camY = mainCam.transform.position.y;
        bool maxOrMin;
        float xConstraint = 0;
        float yConstraint = 0;
        float maxDistance;

        if (constrainX)
        {
            maxOrMin = camX > transform.position.x;
            maxDistance = xLimit * 1.25f;
            if (Mathf.Abs(mainCam.transform.position.x - transform.position.x) < maxDistance && camY > transform.position.y - yLimit && camY < transform.position.y + yLimit)
            {
                xConstraint = transform.position.x + (maxOrMin ? xLimit : -xLimit);
            }
            mainCam.SetXBounds(maxOrMin, xConstraint, transform.position);
        }

        if (constrainY)
        {
            maxOrMin = camY > transform.position.y;
            maxDistance = yLimit * 1.25f;
            if (Mathf.Abs(mainCam.transform.position.y - transform.position.y) < maxDistance && camX > transform.position.x - xLimit && camX < transform.position.x + xLimit)
            {
                yConstraint = transform.position.y + (maxOrMin ? yLimit : -yLimit);
            }
            mainCam.SetYBounds(maxOrMin, yConstraint, transform.position);
        }

    }
}
