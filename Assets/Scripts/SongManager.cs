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
 	public bool pausedSong;

 	public GameObject mostrarCancionPanel;
    public Text mostrarCancionText;

 	//public class MusicPlayer : MonoBehaviour {
 	public GameObject VolumeCanvas;
 	
     static SongManager instance = null;
 	
     void Awake()
     {
     	VolumeCanvas.transform.parent = null;
         if (instance != null)
         {
             Destroy(gameObject);
             Destroy(VolumeCanvas);
         }
         else
         {
             instance = this;
             GameObject.DontDestroyOnLoad(gameObject);
             DontDestroyOnLoad(VolumeCanvas);
         }
     }
 
 	
	 	void Start()
	 	{
	     	audioSource = gameObject.GetComponent<AudioSource>();
	     	shootClip = shoot[0];
			cambiarCancion(shootClip);
			pausedSong = false;
	 	}

		void Update()
		{
			
		    if (Input.GetKeyDown(KeyCode.LeftControl))
		    {
		        int index = Random.Range(0, shoot.Length);
		        shootClip = shoot[index];

		        if(shootClip == audioSource.clip && index == 4)
		        {
		        	shootClip = shoot[index-1];
		        	cambiarCancion(shootClip);
		        }else if(shootClip == audioSource.clip && index == 0){
		        	shootClip = shoot[index+1];
		        	cambiarCancion(shootClip);
		        }else{
		        	cambiarCancion(shootClip);
		        }

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

		    if(Input.GetKeyDown(KeyCode.Space))
	        {
	        	pausedSong = !pausedSong;
	        }

	        if(pausedSong)
	        {
	        	audioSource.Pause();
	        }else if(!pausedSong)
	        {
	        	audioSource.UnPause();
	        }

		    if (Input.GetKeyDown(KeyCode.M))
	            audioSource.mute = !audioSource.mute;
		}

		void cambiarCancion(AudioClip shootClip)
		{
			audioSource.clip = shootClip;
		    audioSource.Play();
		    mostrarCancionPanel.SetActive(true);
        	mostrarCancionText.text = "Playing: " + shootClip.ToString();

        	//m_Text.text = "GameObject Name : " + gameObject.ToString();
		}
}