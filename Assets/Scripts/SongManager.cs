using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    private AudioSource audioSource;
 	public AudioClip[] shoot;
 	private AudioClip shootClip;
 	public string[] songName = {"Hotline","Miami 2","Perturbator","A New Morning","Electric Dreams"};
 	public string actualSongName;
 	public bool pausedSong;
 	public int index;

 	public GameObject mostrarCancionPanel;
    public Text mostrarCancionText;

 	//public class MusicPlayer : MonoBehaviour {
 	public GameObject KeepCanvas;
 	
     static SongManager instance = null;
 	
     
 
 	
	 	void Start()
	 	{
	 		//Scene currentScene = SceneManager.GetActiveScene ();

	 		//string sceneName = currentScene.name;
	     	
	 		if(SceneManager.GetActiveScene().name == "Menu")
	 		{
	 			KeepCanvas.SetActive(false);
	 			mostrarCancionPanel.SetActive(false);
	 		}
	 		//	return;



	     	audioSource = gameObject.GetComponent<AudioSource>();
	     	//shootClip = shoot[0];
			//cambiarCancion(shootClip);
			//pausedSong = false;

			shoot = Resources.LoadAll<AudioClip>("Soundtrack");
			//songName = new string[4]{"Hotline","Miami 2","Perturbator","A New Morning","Electric Dreams"};
			shootClip = shoot[0];
			actualSongName = songName[0];
			index = 0;
			cambiarCancion(shootClip, actualSongName);
			pausedSong = false;
			/*
	        foreach(AudioClip clip in shoot)
	        {
	            //Do something with clip
	        }
	        */
	 	}


		void Awake()
	    {
	    		KeepCanvas.transform.parent = null;
			    //SongNameCanvas.transform.parent = null;
			    if (instance != null)
			    {
			        Destroy(gameObject);
			        Destroy(KeepCanvas);
			        //Destroy(SongNameCanvas);
			    }
			    else
			    {
			        instance = this;
			        GameObject.DontDestroyOnLoad(gameObject);
			        DontDestroyOnLoad(KeepCanvas);
			        //DontDestroyOnLoad(SongNameCanvas);
		   		}
    	}


		void Update()
		{
			if(SceneManager.GetActiveScene().name == "Nivel1")
	 		{
	 			KeepCanvas.SetActive(true);
	 			mostrarCancionPanel.SetActive(true);
	 		}
			//yield return new WaitForSeconds(shootClip.length);
			//int index = Random.Range(0, shoot.Length);
		    //shootClip = shoot[index];

		    if (Input.GetKeyDown(KeyCode.LeftControl))
		    {
		        

		        nuevaCancion(index);

		        /*
		        if(shootClip == audioSource.clip)
		        {
		        	shootClip = shoot[index+1];
		        	cambiarCancion(shootClip);
		        }
		        else
		        {
		        	cambiarCancion(shootClip);
		        }
		        */
		    }

		    if(!audioSource.isPlaying){
		    	nuevaCancion(index);
		    }
		    
		    if(Input.GetKeyDown(KeyCode.Space))
	        {
	        	pausedSong = !pausedSong;
	        }

	        if(pausedSong)
	        {
	        	AudioListener.pause = true;
	        }else if(!pausedSong)
	        {
	        	AudioListener.pause = false;
	        }
	        

		    if (Input.GetKeyDown(KeyCode.M))
	            audioSource.mute = !audioSource.mute;
		}

		void cambiarCancion(AudioClip shootClip, string s)
		{
			audioSource.clip = shootClip;
		    audioSource.Play();
		    mostrarCancionPanel.SetActive(true);
        	mostrarCancionText.text = "LISTENING  TO:    " + actualSongName;

        	//m_Text.text = "GameObject Name : " + gameObject.ToString();
		}

		int nuevaCancion(int i)
		{
			if(AudioListener.pause == true){
				return 0; 
			}
			/*
			if(shootClip == audioSource.clip && index == 4)
		        {
		        	shootClip = shoot[0];
		        	Debug.Log("de la ultima paso a la primera");
		        	cambiarCancion(shootClip);
		        }else if(shootClip == audioSource.clip && index == 0){
		        	shootClip = shoot[1];
		        	Debug.Log("de la primera paso a la segunda");
		        	cambiarCancion(shootClip);
		        }else{
		        	shootClip = shoot[index+1];
		        	Debug.Log("no es ni la primera ni la segunda, pero paso a la siguiente");
		        	cambiarCancion(shootClip);
		        }
		        */
		    //indexFuncion = index; 
		        
		    if(shootClip == audioSource.clip && index == 4)
		    {
		    	index = 0;
		    	shootClip = shoot[0];
		    	Debug.Log("de la ultima paso a la primera");
		    	actualSongName = songName[index];
		        cambiarCancion(shootClip, actualSongName);
		    }else{
		    	shootClip = shoot[index+1];
		    	
		    	Debug.Log("de la " + index + " paso a la ");
		    	index+=1;
		    	Debug.Log(" " + index);
		    	actualSongName = songName[index];
		        cambiarCancion(shootClip, actualSongName);
		    }

		    Debug.Log("salimo de la funcion muchacho " + index);

		    return index;
		    
		}
}