using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public List<SortingContainer> ContainerList;
    private int finishedCount;
    public GameObject winScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen.SetActive(false);
        finishedCount = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoxFinished()
    {
        finishedCount++;
        if(finishedCount == ContainerList.Count)
        {
            Gamewin();
        }
    }

    public void Gamewin()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
