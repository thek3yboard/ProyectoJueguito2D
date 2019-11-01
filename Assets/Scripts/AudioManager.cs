using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
 	public AudioClip[] shoot;
 	private AudioClip shootClip;
 	
 	void Start()
 	{
     	audioSource = gameObject.GetComponent<AudioSource>();
     	shootClip = shoot[0];
		cambiarCancion(shootClip);
 	}

	void Update()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        int index = Random.Range(0, shoot.Length);
	        shootClip = shoot[index];

	        if(shootClip == audioSource.clip && index == 2)
	        {
	        	shootClip = shoot[index-1];
	        	cambiarCancion(shootClip);
	        }else if(shootClip == audioSource.clip && index == 0){
	        	shootClip = shoot[index+1];
	        	cambiarCancion(shootClip);
	        }else if(shootClip == audioSource.clip && index == 1){
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

	    if (Input.GetKeyDown(KeyCode.M))
            audioSource.mute = !audioSource.mute;
	}

	void cambiarCancion(AudioClip shootClip)
	{
		audioSource.clip = shootClip;
	    audioSource.Play();
	}
}
