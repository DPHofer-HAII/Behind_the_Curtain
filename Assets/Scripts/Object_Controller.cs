using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Object_Controller : MonoBehaviour
{
    public GameObject laptop;
    public GameObject bed;
    public GameObject door;

    public GameObject Scene_One;
    public GameObject Scene_Two;
    public GameObject Scene_Three;


    public int phase = 1;
    public bool started = false;

    private VideoPlayer myVideoPlayer;

    // Update is called once per frame
    void Update()
    {
        // Idea: Phase control: Phase 0 (first one): laptop blinks; Phase 1: banana blinks; Phase 2: door blinks
        // Implemented via switch case

        // Phase changes by the number received from the items -> video watched: phase changes

        blingAndSound();
        checkClick();

    }

    void blingAndSound()
    {
        if (phase == 1 && !started)
        {
            ActiveSoundAndLight(laptop);
        }
        else if (phase == 2 && !started)
        {
            ActiveSoundAndLight(bed);
        }
        else if (phase == 3 && !started)
        {
            ActiveSoundAndLight(door);
        }
    }

    void ActiveSoundAndLight(GameObject toBeHandledGameObject)
    {
        toBeHandledGameObject.GetComponent<AudioSource>().Play();
        toBeHandledGameObject.GetComponent<Light>().enabled = true;

        started = true;
    }

    void deactivateEverything(GameObject toBeHandledGameObject)
    {
        toBeHandledGameObject.GetComponent<AudioSource>().Stop();
        toBeHandledGameObject.GetComponent<Light>().enabled = false;
    }

    IEnumerator youPeterPlayThatVideo(GameObject Scene)
    {
        myVideoPlayer = Scene.GetComponent<VideoPlayer>();
        myVideoPlayer.Play();
        Debug.Log(myVideoPlayer.frameCount);
        while (myVideoPlayer.frame != System.Convert.ToInt64(myVideoPlayer.frameCount))
        {
            Debug.Log(myVideoPlayer.frame);
            yield return null;

            if (myVideoPlayer.frame == (System.Convert.ToInt64(myVideoPlayer.frameCount)) - 1)
            {
                myVideoPlayer.Stop();
                Debug.Log("Video stopped");
                //myVideoPlayer.enabled = false;
                if (phase < 4)
                {
                    phase += 1;
                }
                started = false;
                yield return null;
            }
        }


    }

    void checkClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if ((hit.transform.name == "Laptop_On" && phase == 1) || (hit.transform.name == "Laptop_On" && phase == 4))
                {
                    // Change of phase stops the user from klicking on an object a second time
                    started = true;
                    deactivateEverything(laptop);
                    StartCoroutine(youPeterPlayThatVideo(Scene_One));
                }
                else if ((hit.transform.name == "Bed" && phase == 2) || (hit.transform.name == "Bed" && phase == 4))
                {
                    started = true;
                    deactivateEverything(bed);
                    StartCoroutine(youPeterPlayThatVideo(Scene_Two));
                }
                else if ((hit.transform.name == "Door" && phase == 3) || (hit.transform.name == "Door" && phase == 4))
                {
                    started = true;
                    deactivateEverything(door);
                    StartCoroutine(youPeterPlayThatVideo(Scene_Three));
                }
                else if (hit.transform.name == "Hamburger_Menu")
                {
                    SceneManager.LoadScene("Navigation_Page");
                }
            }
        }
    }
}


