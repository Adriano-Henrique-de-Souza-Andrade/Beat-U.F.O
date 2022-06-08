using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_scene : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("singleplay");
    }
}
