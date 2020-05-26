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
            checkForWin();
        }
    }
    void checkForWin() //Function that checks if the player has won
    {
        if(Score >= 5) //Check if score is greater than or equal to 5
        {
                houseText.text = "Come Inside!"; //Change the text to "Come Inside"
                houseText.gameObject.SetActive(true); //Set the text above the house to active
                Invoke("removeText", 2f); //Calls function that removes the text
                Invoke("enterHouse", 1f); //Calls function that opens "You Win" scene
        }
        else //If the player has not won yet
        {
                houseText.text = "Come Back With 5 Gems!"; //Sets house text to "Come Back With 5 Gems!"
                houseText.gameObject.SetActive(true); //Sets houseText to active
                Invoke("removeText", 2f); //Calls function that removes houseText after 2 seconds
        }
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
