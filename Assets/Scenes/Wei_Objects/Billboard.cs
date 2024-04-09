using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class Billboard : MonoBehaviour
{
    public Transform can;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + can.forward, can.up);
    }
}
