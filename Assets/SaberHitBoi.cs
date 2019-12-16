using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberHitBoi : MonoBehaviour
{
    public AudioSource SliceSound;
    public float score = 0;
    public GameObject scoreText;

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "NoteBlock")
        {
            SliceSound.Play();
            score++;
            scorescript notecount = scoreText.GetComponent<scorescript>();
            notecount.NoteCount++;
            Destroy(other.gameObject);
            
            Debug.Log(score);
        }
    }
}
