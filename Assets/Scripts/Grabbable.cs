using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{

    private bool currentlyGrabbed = false;

    [HideInInspector]
    public Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    public void GrabObject()
    {
        rBody.useGravity = false;
        currentlyGrabbed = true;
    }

    public void ReleaseObject()
    {
        rBody.useGravity = true;
        currentlyGrabbed = false;
    }
}
