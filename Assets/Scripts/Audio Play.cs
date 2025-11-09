using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource source;
    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    void Update()
    {
        
    }
}
