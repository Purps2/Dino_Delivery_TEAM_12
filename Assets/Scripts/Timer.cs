using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float initialTime;
    float minutes { get => currentTime / 60; }
    float seconds { get => currentTime % 60; }

    public float currentTime;

    public UnityEvent runOfOutTimeHook;

    private void Awake()
    {
        if (runOfOutTimeHook == null) runOfOutTimeHook = new UnityEvent();
    }

    private void Start()
    {
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = "" + (int)minutes + ":" + (int)seconds;


        if (currentTime < 0) runOfOutTimeHook?.Invoke();
    }

}
