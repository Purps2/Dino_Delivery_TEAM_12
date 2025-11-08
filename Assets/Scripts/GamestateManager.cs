using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GamestateManager : MonoBehaviour
{
    public List<SortingContainer> containers = new List<SortingContainer>();

    public GameObject EndGameUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEndState()
    {
        int endTotal = 0;
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].isSortingFinished == true)
            {
                endTotal++;
            }

            if(endTotal == containers.Count)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        if(EndGameUI != null)
        {
            EndGameUI.SetActive(true);
        }
        Debug.LogError("GAME IS FINISHED");
    }
}
