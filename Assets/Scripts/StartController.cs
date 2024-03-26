using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(PlayDogBark),19.6f);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void PlayDogBark()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            SoundManager.Instance.PlayDogBarkSfx();
    }
}