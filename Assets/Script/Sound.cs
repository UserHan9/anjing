using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public new AudioSource audio;

    private bool audioPlayed = false; // Flag to check if the audio has already been played

    // Start is called before the first frame update
    void Start()
    {
        if (audio == null)
        {
            Debug.LogWarning("AudioSource is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!audioPlayed && audio != null)
        {
            audio.Play();
            audioPlayed = true; // Set the flag to true
            StartCoroutine(StopAudioAfterDelay(5.0f)); // Start coroutine to stop audio after delay
        }
    }

    private IEnumerator StopAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (audio != null && audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
