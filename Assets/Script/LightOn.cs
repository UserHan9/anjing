using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOn : MonoBehaviour
{
    public GameObject targetObject; // Objek yang akan diaktifkan
    public AudioSource targetAudio; // AudioSource yang akan diputar

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object is not assigned!");
        }
        else
        {
            // Pastikan target object tidak aktif saat mulai
            targetObject.SetActive(false);
        }

        if (targetAudio == null)
        {
            Debug.LogWarning("Target audio is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }

        if (targetAudio != null && !targetAudio.isPlaying)
        {
            targetAudio.Play();
        }
    }
}
