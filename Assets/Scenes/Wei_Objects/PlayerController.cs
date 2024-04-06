using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   
    [SerializeField] Transform resetTransform;
    [SerializeField] GameObject player;
    [SerializeField] Camera playerHead;

    public void ResetPosition (){
        // always rotate first before resetting the position
        var rotationAngleY = playerHead.transform.rotation.eulerAngles.y - resetTransform.rotation.eulerAngles.y;

        player.transform.Rotate(0, -rotationAngleY, 0);
        

        //set the position of the player
        var distanceDiff = resetTransform.position - playerHead.transform.position;

        player.transform.position +=  distanceDiff;
    }
}
