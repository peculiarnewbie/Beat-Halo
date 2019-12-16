using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scorescript : MonoBehaviour
{
    public float NoteCount;
    public GameObject Saberru;
    public float realscore = 0;
    public TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaberHitBoi Hits = Saberru.GetComponent<SaberHitBoi>();
        realscore = Hits.score/(NoteCount)*100;
        //Debug.Log("Hits =" + Hits.score + "Note = " + NoteCount);
        scoreText.SetText(realscore.ToString("0")+"%");
    }
}
