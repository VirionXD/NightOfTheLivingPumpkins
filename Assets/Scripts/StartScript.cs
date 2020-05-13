using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
  

        public void Jogar()
        {
            SceneManager.LoadScene("SampleScene");
        }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }



}
