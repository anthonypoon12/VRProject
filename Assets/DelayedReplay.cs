using System.Collections;
using UnityEngine;

public class DelayedReplay : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float interval = 5f; // Time between each loop in seconds
    [Range(0f, 1f)][SerializeField] private float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Dynamically adding an Audiosource component
        source = gameObject.AddComponent<AudioSource>();
        // Dynamically setting the clip
        source.clip = clip;
        // Set volume
        source.volume = volume;

        // Start playing audio loop after delayInSeconds
        StartCoroutine(PlayLoopDelayed());
    }

    // Coroutine to play audio loop delayed
    IEnumerator PlayLoopDelayed()
    {
        yield return new WaitForSeconds(interval);
        PlayLoop();
    }

    // Function to play audio loop
    void PlayLoop()
    {
        // Play the audio clip
        source.Play();
        // Invoke the function again after the audio clip duration
        StartCoroutine(PlayLoopAfterDelay(source.clip.length));
    }

    // Coroutine to play audio loop after delay
    IEnumerator PlayLoopAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayLoop();
    }

    // Function to set the volume of the audio source
    public void SetVolume(float vol)
    {
        volume = Mathf.Clamp01(vol);
        source.volume = volume;
    }
}
