using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrroyMessege : MonoBehaviour
{
    public float timetoDestroy = 2; 
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timetoDestroy);
    }
}
