using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool isTouched;
    public Animator an;

    public void TouchLever() 
    {
        if (!isTouched)
        {
            isTouched = true;
            Debug.Log("The lever has moved!");
            an.SetBool("isTouched", isTouched);
        }
    }
}
