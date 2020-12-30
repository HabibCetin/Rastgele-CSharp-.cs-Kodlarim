//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class RotatingTheMeatBall : MonoBehaviour
{
    #region Degerlerimiz
    public  float rotationSpeed;
    private float dokunmaSuresi     = 0f;
    public  float liftPercentage    = 0f;

    bool isItOnThePlateForLateUpdate;
    bool drag                           = false;
    bool unliftThat                     = false;
    bool calculateTheStartPosition      = false;

    Vector3 birazYukari = new Vector3(0, .3f, 0);
    Vector3 startPosiPosi;

    Rigidbody rb;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        calculateTheStartPosition   = true;
        rb.isKinematic              = false;
        rb.useGravity               = true;

    }

    private void OnMouseDrag()
    {
        if (dokunmaSuresi < .6f)
            dokunmaSuresi += Time.deltaTime;

        if (dokunmaSuresi > .5f)
        {
            if (liftPercentage <= 1)
                liftPercentage += Time.deltaTime + liftPercentage / 20;

            transform.position = Vector3.Slerp(startPosiPosi, startPosiPosi + birazYukari, liftPercentage);
            drag = true;
        }
    }

    private void OnMouseUp()
    {
        if (dokunmaSuresi < .5f)
        {
            isItOnThePlateForLateUpdate                             = true;
            TakingOutTheMeatBall.stopDoingTheMovementCalculation    = false;
            TakingOutTheMeatBall.shouldWeCalculateTheStartPosition  = true;

        }
        else
        {
            dokunmaSuresi   = 0f;
            unliftThat      = true;
            drag            = false;
        }
    }

    private void LateUpdate()
    {
        if (isItOnThePlateForLateUpdate)
        {
            PlateTagCollide.meatBallIsOnThePlate = !PlateTagCollide.meatBallIsOnThePlate;
            isItOnThePlateForLateUpdate = false;
        }
        
    }

    void Update()
    {
        if (calculateTheStartPosition)
        {
            startPosiPosi = transform.position;
            calculateTheStartPosition = false;
        }

        if (Input.GetMouseButtonUp(0))
            drag = false;
    }

    private void FixedUpdate()
    {
        if (drag)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }

        if (unliftThat)
        {
            liftPercentage -= Time.deltaTime + liftPercentage / 20;
            transform.position = Vector3.Lerp(startPosiPosi, startPosiPosi + birazYukari, liftPercentage);
            if (liftPercentage <= 0)
                unliftThat = false;
        }


    }
}
