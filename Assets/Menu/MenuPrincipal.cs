using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
  

	public GameObject instructionsImage;
    public GameObject botonRegresar;
	
	//public Button botonRegresar;
	
    // Start is called before the first frame update
    /*
    void start()
    {
    	//botonRegresar = GetComponent<Button>();
    	//botonRegresar.interactable = false;

    }
    */

    public void EmpezarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MostrarInstrucciones()
    {
    	instructionsImage.SetActive(true);

        botonRegresar.SetActive(true);

    	//botonRegresar.interactable = true;
    	//botonRegresar.interactable = true;
    	/*
    	if(botonRegresar.onClick.AddListener(TaskOnClick))
    	{
    		Debug.Log("tu viejaA EN TANGA");
    	}
    	*/
    	//mybutton.image.overrideSprite = blockA;
    }

    public void VolvelAlMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
