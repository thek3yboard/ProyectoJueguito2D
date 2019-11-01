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
 	}

	void Update()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        int index = Random.Range(0, shoot.Length);
	        shootClip = shoot[index];

	        while(shootClip != audioSource.clip)
	        {
	        	audioSource.clip = shootClip;
	        	audioSource.Play();
	        }
	    }

	    if (Input.GetKeyDown(KeyCode.M))
            audioSource.mute = !audioSource.mute;
	}
}
