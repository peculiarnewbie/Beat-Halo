using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public AudioSource LolSound;
    [SerializeField] private int speed = 2;
    public float lifeTime = 2.6f;
    public float soundTime = 2.6f;
    public GameObject scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("TextMeshPro");
    }


    // Update is called once per frame
    void Update()
    {
        if(soundTime <= 0.5)
        {
            Debug.Log("lol");
            soundTime = 4;
            LolSound.Play();
        }
        if (lifeTime <= 0)
        {

            
            Debug.Log("ded");
            scorescript notecount = scoreText.GetComponent<scorescript>();
            notecount.NoteCount++;
            Destroy(gameObject);

        }
        transform.position += Time.deltaTime * transform.forward * -1 * speed;
        lifeTime -= Time.deltaTime;
        soundTime -= Time.deltaTime;
    }

    
    
}
