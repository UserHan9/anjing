using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sip : MonoBehaviour
{
    public GameObject targetObject; // Objek yang akan diaktifkan

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
