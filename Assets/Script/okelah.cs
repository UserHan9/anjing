using System.Collections;
using UnityEngine;

public class okelah : MonoBehaviour
{
    public GameObject jumpscareObject; // Objek game yang akan muncul sebagai jumpscare
    public AudioSource jumpscareAudio; // AudioSource untuk suara jumpscare
    public float displayTime = 1.0f; // Waktu objek game tampil di layar
    public float distanceFromCamera = 2.0f; // Jarak objek dari kamera

    private bool jumpscareTriggered = false; // Flag untuk memastikan jumpscare hanya terjadi sekali

    void Start()
    {
        if (jumpscareObject == null)
        {
            Debug.LogWarning("Jumpscare object is not assigned!");
        }

        if (jumpscareAudio == null)
        {
            Debug.LogWarning("Jumpscare audio is not assigned!");
        }

        // Sembunyikan objek jumpscare saat mulai
        if (jumpscareObject != null)
        {
            jumpscareObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!jumpscareTriggered && jumpscareObject != null && jumpscareAudio != null)
        {
            jumpscareTriggered = true;
            StartCoroutine(TriggerJumpscare(other.transform));
        }
    }

    private IEnumerator TriggerJumpscare(Transform characterTransform)
    {
        // Temukan kamera dari karakter
        Camera characterCamera = characterTransform.GetComponentInChildren<Camera>();
        if (characterCamera != null)
        {
            // Tempatkan objek jumpscare di depan kamera
            Vector3 jumpscarePosition = characterCamera.transform.position + characterCamera.transform.forward * distanceFromCamera;
            jumpscareObject.transform.position = jumpscarePosition;

            // Set rotasi objek jumpscare agar menghadap kamera
            jumpscareObject.transform.rotation = Quaternion.LookRotation(characterCamera.transform.forward);

            // Tampilkan objek jumpscare dan mainkan audio
            jumpscareObject.SetActive(true);
            jumpscareAudio.Play();

            // Tunggu selama displayTime
            yield return new WaitForSeconds(displayTime);

            // Sembunyikan objek jumpscare
            jumpscareObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Character does not have a camera component!");
        }
    }
}
