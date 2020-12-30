using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SwipedObject : MonoBehaviour
{
    #region Değerler

    public Animator animator;
    private float bekleKnk = 0.2f;

    private float sideJumpsSpeed = 1.2f;
    private float jumpSpeed = 1.2f;
    private float sonHiz = 1f;

    #endregion

    #region Kaydırma kontrolleri
    void Update()
    {

        if (SwipeManager.swipeLeft)
        {
            animator.SetBool("isSwipedLeft", true);
            Invoke("LeftFalser", bekleKnk);
        }

        if (SwipeManager.swipeRight)
        {
            animator.SetBool("isSwipedRight", true);
            Invoke("RightFalser", bekleKnk);
        }

        if (SwipeManager.swipeUp)
        {
            animator.SetBool("isSwipedUp", true);
            Invoke("UpFalser", bekleKnk);
        }

    }
    #endregion

    #region Animasyon Hızı Arttırıcı

    private void FixedUpdate()
    {
        //StartCoroutine("KosuHiziArttirici");

        sonHiz = (Collidedetection.score / 50f) + 1.2f + (AGameManager.gameSpeedBoost/50f);
        animator.SetFloat("runMultiplier", sonHiz);

        sideJumpsSpeed = (Collidedetection.score / 80f) + 1f + (AGameManager.gameSpeedBoost/80f);
        animator.SetFloat("sideJumpsSpeed", sideJumpsSpeed);

        jumpSpeed = (Collidedetection.score / 120f) + 1f + (AGameManager.gameSpeedBoost/120f);
        animator.SetFloat("jumpSpeed", jumpSpeed);

    }

    #endregion

    #region Coroutines
    IEnumerator KosuHiziArttirici ()
    { 
       
            yield return new WaitForSeconds(1f);
    }
    
    #endregion

    #region Falsers
    private void LeftFalser ()
    {
        animator.SetBool("isSwipedLeft", false);
    }

    private void RightFalser ()
    {
        animator.SetBool("isSwipedRight", false);
    }

    private void UpFalser()
    {
        animator.SetBool("isSwipedUp", false);
    }
    #endregion
}
