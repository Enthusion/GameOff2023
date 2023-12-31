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
    private Vector3 constraintPointXMax;
    private Vector3 constraintPointXMin;
    private Vector3 constraintPointYMax;
    private Vector3 constraintPointYMin;
    private float xMax = 0;
    private float xMin = 0;
    private float yMax = 0;
    private float yMin = 0;
    private bool inactivePlayerfollwing;

    private void Start()
    {
        target1 = subject1.GetComponent<PlayerController>();
        target2 = subject2.GetComponent<PlayerController>();
        activeTarget = target1.characterId == GameManager.Instance.GetActiveCharacter() ? target1 : target2;
    }
    // Update is called once per frame
    private void Update()
    {
        PlayerController lastActiveTarget = activeTarget;
        if (!target1.Active) activeTarget = target2;
        else activeTarget = target1;
        inactivePlayerfollwing = target1.Following || target2.Following;
        if (lastActiveTarget != activeTarget) GameManager.Instance?.UpdateActiveCharacter();
        if (target1.Active && target2.Active)
        {
            Debug.Log("Two active characters detected!");
            activeTarget = target1.characterId == GameManager.Instance.GetActiveCharacter() ? target1 : target2;
            activeTarget.ForceToActive();
            if (target1 == activeTarget)
            {
                if (inactivePlayerfollwing) target2.ForceToFollow();
                else target2.ForceToWaiting();
            }
            else
            {
                if (inactivePlayerfollwing) target1.ForceToFollow();
                else target1.ForceToWaiting();
            }

        }
        else if (!target1.Active && !target2.Active)
        {
            Debug.Log("Two inactive characters detected!");
            target1.ForceToActive();
            if (inactivePlayerfollwing) target2.ForceToFollow();
            else target2.ForceToWaiting();
        }
        lookOffset = activeTarget.Sprite.flipX ? -0.75f : 2.25f;
        targetPosition = new Vector3(activeTarget.transform.position.x + offsetToCenter.x + lookOffset, activeTarget.transform.position.y + offsetToCenter.y, transform.position.z);
        //Constrain the camera
        if (xMax != 0 && targetPosition.x < xMax)
        {
            targetPosition = new Vector3(xMax, targetPosition.y, targetPosition.z);
        }
        if (xMin != 0 && targetPosition.x > xMin)
        {
            targetPosition = new Vector3(xMin, targetPosition.y, targetPosition.z);
        }
        if (yMax != 0 && targetPosition.y < yMax)
        {
            targetPosition = new Vector3(targetPosition.x, yMax, targetPosition.z);
        }
        if (yMin != 0 && targetPosition.y > yMin)
        {
            targetPosition = new Vector3(targetPosition.x, yMin, targetPosition.z);
        }

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
        AudioManager.Instance.SetPosition(targetPosition);
    }

    public void SetXBounds(bool maxMin, float xLimiter, Vector3 origin)
    {
        bool valueFilled = (maxMin ? xMax : xMin) != 0;
        //If the constrain is already set and incoming constraint is not from the point currently providing the constraint
        if (valueFilled && origin != (maxMin ? constraintPointXMax : constraintPointXMin)) return;
        if (maxMin)
        {
            xMax = xLimiter;
            constraintPointXMax = origin;
        }
        else
        {
            xMin = xLimiter;
            constraintPointXMin = origin;
        }
    }

    public void SetYBounds(bool maxMin, float yLimiter, Vector3 origin)
    {
        bool valueFilled = (maxMin ? yMax : yMin) != 0;
        //If the constrain is already set and incoming constraint is not from the point currently providing the constraint
        if (valueFilled && origin != (maxMin ? constraintPointYMax : constraintPointYMin)) return;
        if (maxMin)
        {
            yMax = yLimiter;
            constraintPointYMax = origin;
        }
        else
        {
            yMin = yLimiter;
            constraintPointYMin = origin;
        }
    }


}
