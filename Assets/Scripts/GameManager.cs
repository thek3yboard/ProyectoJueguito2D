using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	bool gameHasEnded = false;

	public float restartDelay = 2f;

	public GameObject gameOverPanel;
    public Text gameOverText;

    public void EndGameLost()
    {
    	
        if(gameHasEnded == false)
        {
        	gameHasEnded = true;
        	gameOverPanel.SetActive(true);
        	gameOverText.text = "YOU   LOST";
        	Invoke("Restart", restartDelay);
        }
    }

    public void EndGameWon()
    {
        
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverPanel.SetActive(true);
            gameOverText.text = "YOU   WON";
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
    	gameOverPanel.SetActive(false);
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
