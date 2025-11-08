using UnityEngine;
using UnityEngine.Events;

public class EventHook : MonoBehaviour
{
    public UnityEvent Hook;

    private void Awake()
    {
        if (Hook == null) Hook = new UnityEvent();
    }
    public void Execute() => Hook?.Invoke();
}
