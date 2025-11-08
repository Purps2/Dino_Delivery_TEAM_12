using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SortingContainer : MonoBehaviour
{

    public SortingShape sortType = SortingShape.None;

    public List<Light> lights = new List<Light>();

    private int currentLightIndex = 0;

    public bool isSortingFinished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grabbable")
        {
            Grabbable item = other.GetComponent<Grabbable>();
            if(item.sortingShape == sortType)
            {
                if(lights != null && lights.Count >= currentLightIndex + 1)
                {
                    Destroy(item.gameObject);
                    lights[currentLightIndex].enabled = true;
                    if(currentLightIndex + 1 == lights.Count)
                    {
                        isSortingFinished = true;
                        FindAnyObjectByType<GamestateManager>().CheckEndState();
                    }
                    else
                    {
                        currentLightIndex++;
                    }
                }
            }
        }
    }
}
