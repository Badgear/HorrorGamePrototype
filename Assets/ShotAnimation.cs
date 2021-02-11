using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnimation : MonoBehaviour
{
    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_animator.SetTrigger("shoot");
        }
    }
}
