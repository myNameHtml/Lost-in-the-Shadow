using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Hub");
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
