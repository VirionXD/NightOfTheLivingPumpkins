using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudScript : MonoBehaviour
{
    public AudioSource[] Sons;
    public Text QuantAboboras;
    public Text QuantTempo;
    float timeLeft = 30.0f;

    // Update is called once per frame
    private void Start()
    {
        timeLeft = 30.0f;
    }

    void Update()
    {
        QuantAboboras.text = Personagem3D.aboboras.ToString();
        QuantTempo.text = timeLeft.ToString();

        timeLeft -= Mathf.Abs(Time.deltaTime);
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Loser");
        }
    }
}
