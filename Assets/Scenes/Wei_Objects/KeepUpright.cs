using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    public Transform headTransform; // Drag the "head" of the zombie here in the Inspector
    private Rigidbody rb;
    private FixedJoint fixedJoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = headTransform.GetComponent<Rigidbody>(); // Assuming the head has a Rigidbody
        fixedJoint.anchor = Vector3.zero; // Center the joint
        fixedJoint.connectedAnchor = Vector3.zero; // Connect to the center of the head
        fixedJoint.enablePreprocessing = false; // Disable joint preprocessing for performance
        fixedJoint.massScale = 1; // Set mass scale to 1
        fixedJoint.connectedMassScale = 1; // Set connected mass scale to 1
    }
}
