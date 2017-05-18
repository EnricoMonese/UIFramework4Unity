using UnityEngine;
using System.Collections;

public class AudioBotao : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip selecionar, confirmar;
	
	private static AudioBotao singleton;

	void Awake(){
		AudioListener.pause = false;
		singleton = this;
		audioSource.ignoreListenerPause=true;
	}

	public void Confirmar(){
		audioSource.PlayOneShot(confirmar);
	}

	public void Selecionar(){
		audioSource.PlayOneShot(selecionar);
	}

	public static void SConfirmar(){
		if(singleton)
			singleton.Confirmar();
	}

	public static void SSelecionar(){
		if(singleton)
			singleton.Selecionar();
	}
}
