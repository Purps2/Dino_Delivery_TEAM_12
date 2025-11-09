using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float initialTime;
    float minutes { get => currentTime / 60; }
    float seconds { get => currentTime % 60; }

    public GameObject endScreen;

    public float currentTime;

    public UnityEvent runOfOutTimeHook;

    private void Awake()
    {
        if (runOfOutTimeHook == null) runOfOutTimeHook = new UnityEvent();
    }

    private void Start()
    {
        endScreen.SetActive(false);
        Time.timeScale = 1;
        currentTime = initialTime;
    }

    public void Endgame()
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = "" + (int)minutes + ":" + (int)seconds;


        if (currentTime < 0)
        {
            Endgame();
        }

    }

}
