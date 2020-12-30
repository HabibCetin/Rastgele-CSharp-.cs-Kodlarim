//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MeatBallCooking : MonoBehaviour
{
    //Eger Hata İle Karsilasirsan Bir Alttaki Public idi
    private Renderer meatItSelf;
    
    private float cookerCounter;

    void Start()
    {
        cookerCounter 	= 0f;
        meatItSelf 	= gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (CookerColliderBehave.flameIsOn && CookerColliderBehave.meatBallCookIt)
        {
            if (CookerColliderBehave.meatBallCookRight)
            {
                if (CookerColliderBehave.meatBallJustCheckForOnce)
                {
                    //JustCheckForOnce Sayesinde Ocaktan Yemegi cikardigimizda yemegin durumu sifirlanmiyor ve ne kadar pişmişse o durumda bekliyor
                    cookerCounter = meatItSelf.material.GetFloat("_RightMeatBallCooker");
                    CookerColliderBehave.meatBallJustCheckForOnce = false;
                }
                cookerCounter += Time.deltaTime / 15;
                meatItSelf.material.SetFloat("_RightMeatBallCooker", cookerCounter);
            }


            if (CookerColliderBehave.meatBallCookLeft)
            {
                if (CookerColliderBehave.meatBallJustCheckForOnce)
                {
                    cookerCounter = meatItSelf.material.GetFloat("_LeftMeatBallCooker");
                    CookerColliderBehave.meatBallJustCheckForOnce = false;
                }
                cookerCounter += Time.deltaTime / 15;
                meatItSelf.material.SetFloat("_LeftMeatBallCooker", cookerCounter);
            }


        }
    }
}
