using System.Collections;
using System.Collections.Generic;
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
        // If the audio source is not already playing
        if (!source.isPlaying)
        {
            // Play the audio clip
            source.Play();
            // Invoke the function again after interval seconds
            Invoke("PlayLoop", interval);
        }
    }

    // Function to set the volume of the audio source
    public void SetVolume(float vol)
    {
        volume = Mathf.Clamp01(vol);
        source.volume = volume;
    }
}
