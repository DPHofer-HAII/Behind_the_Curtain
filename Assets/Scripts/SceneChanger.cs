using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void Navigation_Page()
    {
        SceneManager.LoadScene("Navigation_Page");
    }

    public void Resources()
    {
        SceneManager.LoadScene("Resources");
    }

    public void About_Depression()
    {
        SceneManager.LoadScene("About_Depression");
    }

    public void VR_Experience()
    {
        SceneManager.LoadScene("VR_Room_1");
    }

    public void About_Depression_Key_Facts_1()
    {
        SceneManager.LoadScene("About_Depression_Key_Facts_1");
    }

    public void About_Depression_Contributing_Factors_1()
    {
        SceneManager.LoadScene("About_Depression_Contributing_Factors_1");
    }

    public void About_Depressions_Symptoms_and_Patterns_1()
    {
        SceneManager.LoadScene("About_Depression_Symptoms_and_Patterns_1");
    }

    public void Next_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Previous_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
