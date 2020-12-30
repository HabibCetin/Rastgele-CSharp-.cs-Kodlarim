//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameManagerFoodSpawner : MonoBehaviour
{

    #region Degerlerimiz
    
    public GameObject tomahawkRaw;
    public GameObject meatBallRaw;
    public GameObject potatoRaw;

    public  GameObject sectionOne;
    public  GameObject hand;
    private GameObject instantiatedObject;
    private GameObject plate;

    private bool lerpingBooltomahawk;
    private bool lerpingBoolMeatBall;
    private bool lerpingBoolPotato;
    public static bool doWeHaveASteak       = false;
    public static bool doWeHaveAMeatBall    = false;
    public static bool doWeHaveAPotato      = false;

    private float lerpingFloatTomahawk  = 1f;
    private float lerpingFloatMeatBall  = 1f;
    private float lerpingFloatPotato    = 1f;

    private Vector3 spawnOffSet = new Vector3(0, 0, 0);

    public Rigidbody rbtomahawk;
    public Rigidbody rbMeatBall;
    public static bool potatoSlicesRB = true;


    #endregion

    private void Awake()
    {
        Physics.gravity = new Vector3(0, -.35f, 0);
        plate = GameObject.FindGameObjectWithTag("Plate");
    }

    void Update()
    {
        #region Instantiating The Tomahawk 

        if ((PlateSpawn.doWeHaveAPlate && InGameButton.getUsATomahawk && !doWeHaveASteak))
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            instantiatedObject = Instantiate(tomahawkRaw, sectionOne.transform.position, sectionOne.transform.rotation);
            rbtomahawk = instantiatedObject.GetComponent<Rigidbody>();
            instantiatedObject.transform.SetParent(plate.transform);
            lerpingBooltomahawk = true;
            InGameButton.getUsATomahawk = false;
            doWeHaveASteak = true;
        }
        else
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            InGameButton.getUsATomahawk = false;
        }

        #endregion

        #region Instantiating The MeatBall

        if ((PlateSpawn.doWeHaveAPlate && InGameButton.getUsAMeatBall && !doWeHaveAMeatBall))
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            instantiatedObject = Instantiate(meatBallRaw, sectionOne.transform.position, sectionOne.transform.rotation);
            rbMeatBall = instantiatedObject.GetComponent<Rigidbody>();
            instantiatedObject.transform.SetParent(plate.transform);
            lerpingBoolMeatBall = true;
            InGameButton.getUsAMeatBall = false;
            doWeHaveAMeatBall = true;
        }
        else
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            InGameButton.getUsAMeatBall = false;
        }

        #endregion

        #region Instantiating The Potato

        if ((PlateSpawn.doWeHaveAPlate && InGameButton.getUsAPotato && !doWeHaveAPotato))
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            instantiatedObject = Instantiate(potatoRaw, sectionOne.transform.position, sectionOne.transform.rotation);
            instantiatedObject.transform.SetParent(plate.transform);
            lerpingBoolPotato = true;
            InGameButton.getUsAPotato = false;
            doWeHaveAPotato = true;
            potatoSlicesRB = false;
        }
        else
        {
            if (plate == null)
                plate = GameObject.FindGameObjectWithTag("Plate");

            InGameButton.getUsAPotato = false;
        }


        #endregion


        if (lerpingBoolPotato)
        {
            potatoSlicesRB = false;
            lerpingFloatPotato -= Time.deltaTime + lerpingFloatPotato / 20;
            instantiatedObject.transform.position = Vector3.Lerp(hand.transform.position + spawnOffSet, sectionOne.transform.position, lerpingFloatPotato);
        }



        if (lerpingBooltomahawk)
        {
            rbtomahawk.isKinematic = true;
            rbtomahawk.useGravity = false;
            lerpingFloatTomahawk -= Time.deltaTime + lerpingFloatTomahawk / 20;
            instantiatedObject.transform.position = Vector3.Lerp(hand.transform.position, sectionOne.transform.position, lerpingFloatTomahawk);
        }

        if (lerpingBoolMeatBall)
        {
            rbMeatBall.isKinematic = true;
            rbMeatBall.useGravity = false;
            lerpingFloatMeatBall -= Time.deltaTime + lerpingFloatMeatBall / 20;
            instantiatedObject.transform.position = Vector3.Lerp(hand.transform.position, sectionOne.transform.position, lerpingFloatMeatBall);
        }



        if (lerpingFloatPotato <= 0f)
        {
            lerpingBoolPotato = false;
            lerpingFloatPotato = 1f;
        }


        if (lerpingFloatTomahawk <= 0f)
        {
            lerpingBooltomahawk = false;
            lerpingFloatTomahawk = 1f;
        }

        if (lerpingFloatMeatBall <= 0f)
        {
            lerpingBoolMeatBall = false;
            lerpingFloatMeatBall = 1f;
        }

    }
}
