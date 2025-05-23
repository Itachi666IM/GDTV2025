using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float timeToWin;
    
    void Update()
    {
        if(Time.time>timeToWin)
        {
            Debug.Log("You Survived!");
            SceneManager.LoadScene("Win");
        }
    }
}
