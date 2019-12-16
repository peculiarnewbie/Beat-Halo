using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Spawner : MonoBehaviour
{
    List<int> WhichNote = new List<int>()
    {
        //intro
        /*5,0,0,0,  0,0,2,3,    4,0,0,0,     0,0,0,0,     4,0,0,0,    0,0,0,0,    0,0,0,0,*/      2,3,4,0,
        0,0,0,0,    0,0,0,0,    0,0,0,0,     4,3,2,0,     0,0,0,0,    0,0,0,0,    0,0,0,0,      0,0,0,0,
        5,0,0,0,    0,0,0,0,    0,0,0,0,     4,3,2,0,     0,0,0,0,    0,0,0,0,    0,0,0,0,      2,3,4,0,
        0,0,0,0,    0,0,0,0,    0,0,0,0,     4,3,2,0,     0,0,0,0,    0,0,0,0,    0,0,0,0,      0,0,0,0,

        //verse 1
        5,0,0,0,    1,0,0,0,    5,0,0,0,     3,0,0,0,     5,0,0,0,    1,0,0,0,    5,0,2,0,      5,0,2,0,
        0,0,0,0,    1,0,0,0,    5,0,0,0,     3,0,0,0,     5,0,0,0,    1,0,0,0,    5,0,2,0,      5,0,2,0,
        5,0,0,0,    2,0,0,0,    5,0,0,0,     4,0,0,0,     5,0,0,0,    2,0,0,0,    5,0,0,0,      4,0,0,0,
        5,0,0,0,    2,0,0,0,    5,0,0,0,     4,0,0,0,     5,0,0,0,    2,0,0,0,    5,0,0,0,      4,0,0,0,

        5,0,0,0,    1,0,0,0,    5,0,0,0,     3,0,0,0,     5,0,0,0,    1,0,0,0,    5,0,4,0,      5,0,4,0,
        0,0,0,0,    1,0,0,0,    5,0,0,0,     3,0,0,0,     5,0,0,0,    1,0,0,0,    5,0,4,0,      5,0,4,0,
        5,0,0,0,    2,0,0,0,    5,0,0,0,     4,0,0,0,     5,0,0,0,    2,0,0,0,    5,0,0,0,      4,0,0,0,
        5,0,0,0,    0,0,0,0,    0,0,0,0,     5,0,0,0,     0,0,0,0,    0,0,2,0,    1,0,0,5,      0,0,4,0,

        //prechorus
        5,0,0,0,    0,0,5,0,    0,0,0,0,    0,0,0,0,    3,0,0,4,    0,0,1,0,    2,0,5,0,    1,0,0,0,
        5,0,0,0,    0,0,5,0,    0,0,0,0,    0,0,0,0,    3,0,0,4,    0,0,1,0,    2,0,5,0,    1,0,0,0,
        5,0,0,0,    0,0,5,0,    0,0,0,0,    0,0,0,0,    3,0,0,4,    0,0,1,0,    2,0,5,0,    1,0,1,0,
        5,0,0,0,    0,0,0,0,    0,0,0,0,    5,0,0,0,    0,0,0,0,    0,0,0,0,    0,0,0,0,    0,0,0,0,

        //chorus
        2,0,2,0,    0,0,0,0,    4,0,0,0,    3,0,0,0,    1,0,1,0,    0,0,0,0,    5,0,5,0,    0,0,0,0,
        3,0,3,0,    0,0,0,0,    2,0,0,0,    1,0,0,0,    2,0,2,0,    0,0,3,0,    3,0,0,4,    0,0,4,0,
        1,0,1,0,    0,0,0,0,    3,0,0,0,    4,0,0,0,    3,0,3,0,    0,0,0,0,    1,0,0,0,    5,0,5,0,
        0,0,0,0,    0,0,3,3,    3,0,0,4,    0,0,4,0,    0,0,0,0,    0,0,3,3,    3,0,0,4,    0,0,4,0,

        2,0,2,0,    0,0,0,0,    4,0,0,0,    3,0,0,0,    1,0,1,0,    0,0,0,0,    5,0,5,0,    0,0,0,0,
        1,0,1,0,    0,0,0,0,    2,0,0,0,    1,0,0,0,    2,0,2,0,    0,0,3,0,    3,0,0,2,    0,0,2,0,
        4,0,4,0,    0,0,0,0,    3,0,0,0,    4,0,0,0,    3,0,3,0,    0,0,0,0,    1,0,0,0,    5,0,5,0,
        0,0,0,0,    0,0,1,1,    1,0,0,2,    0,0,2,0,    0,0,0,0,    0,0,1,1,    1,0,0,2,    0,0,2,0,
    };
    public AudioSource MusicSource;
    public GameObject[] cubes;
    public int NoteMark = 0;
    public Transform[] points;
    public double beat;
    public float timer = 0f;
    public string timerReset = "y";

    private static Timer aTimer;
    // Start is called before the first frame update
    void Start()
    {
        /*Timer aTimer = new Timer();
        aTimer.Elapsed += new ElapsedEventHandler(playNote);
        aTimer.Interval = 125;
        aTimer.Stop();*/
        beat += Time.time;
        MusicSource.Play();
   
    }
    
    // Update is called once per frame
    void Update()
    {
        //aTimer.Enabled = false;
        if (beat - Time.time <= 0.1f)
        {
            //Debug.Log("suk");
            spawnNote();
            beat += 0.12605f;
        }
        //Debug.Log(beat - Time.time);
        /*aTimer.AutoReset = true;
        aTimer.Enabled = true;*/
    }

    /*void OnApplicationQuit()
    {
        aTimer.Stop();
    }

    void playNote(object sender, ElapsedEventArgs e)
    {
        spawnNote();
    }*/

    public void spawnNote()
    {
        //Debug.Log("yaapaei");
        //yield return new WaitForSeconds(timer);
        if (WhichNote[NoteMark] == 0)
        {

        }
        else if (WhichNote[NoteMark] == 1)
        {
            GameObject cube = Instantiate(cubes[1], points[0]);
            cube.transform.localPosition = Vector3.zero;
        }
        else if (WhichNote[NoteMark] == 2)
        {
            GameObject cube = Instantiate(cubes[1], points[1]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * 1);
        }
        else if (WhichNote[NoteMark] == 3)
        {
            GameObject cube = Instantiate(cubes[1], points[2]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * 2);
        }
        else if (WhichNote[NoteMark] == 4)
        {
            GameObject cube = Instantiate(cubes[1], points[3]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * 3);
        }
        else if (WhichNote[NoteMark] == 5)
        {
            GameObject cube = Instantiate(cubes[0], points[4]);
            cube.transform.localPosition =Vector3.zero;
        }
        NoteMark += 1;
    }
}
