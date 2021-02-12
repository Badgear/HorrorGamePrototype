using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShotAnimation : MonoBehaviour
{
    Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
       Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ani.SetTrigger("shoot");
        }
    }
}
