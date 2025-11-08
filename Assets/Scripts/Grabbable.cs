using UnityEngine;

public enum SortingShape
{
    None,
    Square,
    Triangle,
    Circle
}

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{

    private bool currentlyGrabbed = false;

    [HideInInspector]
    public Rigidbody rBody;
    public SortingShape sortingShape = SortingShape.None;
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
