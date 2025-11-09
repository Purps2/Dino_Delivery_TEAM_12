using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortingContainer : MonoBehaviour
{

    public SortingShape sortType = SortingShape.None;

    public List<Light> lights = new List<Light>();

    private int currentLightIndex = 0;

    public bool isSortingFinished = false;
    public UnityEvent finishHook;
    public UnityEvent progressHook;

    private GameManager manager;

    private void Awake()
    {
        if (finishHook == null) finishHook = new UnityEvent();
        if (progressHook == null) progressHook = new UnityEvent();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<GameManager>();  
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
                        manager.BoxFinished();
                        finishHook?.Invoke();
                    }
                    else
                    {
                        currentLightIndex++;
                        progressHook?.Invoke();
                    }
                }
            }
        }
    }
}
