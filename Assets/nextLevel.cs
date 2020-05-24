using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public GameObject playerObject;
    public Text houseText;
    private int Score;
    private int Health;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Score >= 5)
            {
                winGame();
            }
            else
            {
                noWin();
            }
        }
    }

    void winGame()
    {
        houseText.gameObject.SetActive(true);
        houseText.text = "Come Inside!";
        Invoke("removeText", 2f);
        Invoke("enterHouse", 1f);
    }

    void noWin()
    {
        houseText.text = "Come Back With 5 Gems!";
        houseText.gameObject.SetActive(true);
        Invoke("removeText", 2f);
    }
    void Start()
    {
        houseText.gameObject.SetActive(false);
    }

    void removeText()
    {
        houseText.gameObject.SetActive(false);
    }

    void Update()
    {
        captureGem gemScript = playerObject.GetComponent<captureGem>();
        Score = gemScript.currentScore;
    }

    void enterHouse() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
