using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Play1()
    {
        SceneManager.LoadScene(0);
    }

    public void Play2()
    {
        SceneManager.LoadScene(1);
    }
    public void Play3()
    {
        SceneManager.LoadScene(2);
    }

    public void Play4()
    {
        SceneManager.LoadScene(3);
    }
}
