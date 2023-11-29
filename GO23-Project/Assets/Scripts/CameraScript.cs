using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject subject1;
    private PlayerController target1;
    public GameObject subject2;
    private PlayerController target2;
    private PlayerController activeTarget;
    public Vector2 offsetToCenter; //-0.9, -0.45
    private float lookOffset;
    [SerializeField]
    private float trackingSpeed1; //7
    [SerializeField]
    private float trackingSpeed2; //3
    [SerializeField]
    private float switchSpeed; //10
    private float panSpeed;
    private float distanceMin = 0.001f;
    private float distcaneMax = 7.5f;
    private Vector3 targetPosition;

    //public AK.Wwise.Event SwapToMort;
    //public AK.Wwise.Event SwapToVita;
    // public GameObject Testsound;

    private void Start()
    {
        target1 = subject1.GetComponent<PlayerController>();
        target2 = subject2.GetComponent<PlayerController>();
        activeTarget = target1.primaryPlayer ? target1 : target2;
    }
    // Update is called once per frame
    private void Update()
    {
        if (!target1.Active) activeTarget = target2;
        else activeTarget = target1;
        //Instantiate sound object?
        lookOffset = activeTarget.Sprite.flipX ? -0.75f : 2.25f;
        targetPosition = new Vector3(activeTarget.transform.position.x + offsetToCenter.x + lookOffset, activeTarget.transform.position.y + offsetToCenter.y, transform.position.z);
        float distanceTo = Vector3.Distance(transform.position, targetPosition);
        if (distanceTo <= distanceMin)
        {
            panSpeed = 0.0f;
        }
        else if (distanceTo < 3.0f)
        {
            panSpeed = trackingSpeed1;
        }
        else if (distanceTo < distcaneMax)
        {
            panSpeed = trackingSpeed2;
        }
        else
        {
            panSpeed = switchSpeed;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, panSpeed * Time.deltaTime);
    }


}