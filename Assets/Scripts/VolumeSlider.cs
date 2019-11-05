using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSlider : MonoBehaviour
{
	public Slider volume;
	public AudioSource music;

	public float volumeOverTime;
	public float previousValue = 0;
    /*
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    */

    

	void Start()
	{
		volume.value = 0.5f;
	}

    // Update is called once per frame
    void Update()
    {
        music.volume = volume.value;

        if(Input.GetKey(KeyCode.Q))
        {
        	volume.value -= volumeOverTime * Time.deltaTime;
        	music.volume = volume.value;
        	//	music.volume -= volumeOverTime * Time.deltaTime;
        	//	music.volume = volume.value;
        }else if(Input.GetKey(KeyCode.E)){
        	volume.value += volumeOverTime * Time.deltaTime;
        	music.volume = volume.value;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
        	if(music.volume > 0){
        		previousValue = volume.value;
        		music.mute = !music.mute;
            	volume.value = 0;
        	}else{
        		volume.value = previousValue;
        		music.mute = !music.mute;
        	}
        }     
    }
}
