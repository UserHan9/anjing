using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public string sceneName;  // Nama scene yang ingin Anda muat

    // Fungsi ini dipanggil ketika objek lain memasuki collider yang memiliki isTrigger diaktifkan
    private void OnTriggerEnter(Collider other)
    {
        // Anda bisa menambahkan logika untuk memeriksa objek lain yang masuk ke trigger, misalnya hanya player
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
