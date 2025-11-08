using Unity.VisualScripting;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    private Grabbable currentlyGrabbedObject;

    public Transform grabPoint; // Assign this in the Inspector
    public float moveToGrabPointSpeed = 2f;
    public GameObject grabObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GrabObject();


        if (currentlyGrabbedObject != null)
        {
            Vector3 currentPosition = currentlyGrabbedObject.rBody.position;
            Vector3 desiredPosition = Vector3.Lerp(currentPosition, grabPoint.position, Time.fixedDeltaTime * moveToGrabPointSpeed);
            Vector3 velocity = (desiredPosition - currentPosition) / Time.fixedDeltaTime;

            currentlyGrabbedObject.rBody.linearVelocity = velocity;
            Debug.Log("HOLDING ONTO OBJECT");


            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Releasing Object!");
                ReleaseObject();
            }
        }
    }


    private void GrabObject()
    {
        float maxGrabDistance = 6f; // Set your desired max distance

        // Create a ray from the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        RaycastHit hit;

        // Limit the raycast distance
        if (Physics.Raycast(ray, out hit, maxGrabDistance))
        {
            Debug.Log("Hit " + hit.collider.name);
            Grabbable grabbies = hit.collider.GetComponent<Grabbable>();

            if (grabbies != null)
            {
                Debug.Log("Hit a grabbable and is grabbing!");
                if (Input.GetMouseButton(0))
                {
                    grabbies.GrabObject();
                    currentlyGrabbedObject = grabbies;
                }
                grabObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("No hit detected within range.");
            grabObject.SetActive(false);
        }
    }


    private void ReleaseObject()
    {
        currentlyGrabbedObject.ReleaseObject();
        currentlyGrabbedObject = null;
    }
}
