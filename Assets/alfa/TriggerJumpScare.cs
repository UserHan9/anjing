using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpScare : MonoBehaviour
{
    public GameObject jump;
    public GameObject jumpTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        jumpTarget.SetActive(false);
        jump.SetActive(true);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.0f);
        jump.SetActive(false);
        jumpTarget.SetActive(true);
    }
}
