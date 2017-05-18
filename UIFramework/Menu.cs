using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject firstSelected;
	public GameObject root; 
	public GraphicRaycaster raycaster;
	public bool remenberLastSelection;
	public float activeOtherTime, disableTime;
	public Button[] transitionButtons;
	public UnityEvent onFadeIn,onFadeOut;

	private ButtonEvent[] buttonEvents;

	void Reset(){
		raycaster = GetComponent<GraphicRaycaster>();
		root = gameObject;
	}

	void Awake () {
		buttonEvents = gameObject.GetComponentsInChildren<ButtonEvent>(true);
	}

	public void Disable(){
		root.SetActive(false);
	}

	public void Enable(){
		root.SetActive(true);
		if(EventSystem.current)
			EventSystem.current.SetSelectedGameObject(firstSelected);
	}

	public void IniFadeIn(){
		Enable();
		StopCoroutine("EnableFadeIn");
		StopCoroutine("DisableFadeOut");
		onFadeIn.Invoke();
		raycaster.enabled = true;
		for (int i = 0;i < buttonEvents.Length; i++) {
			buttonEvents[i].enabled = true;
		}
	}

	public void IniFadeOut(Menu m){
		onFadeOut.Invoke();
		if(remenberLastSelection){
			firstSelected = EventSystem.current.currentSelectedGameObject;
		}
		raycaster.enabled = false;
		for (int i = 0; i < buttonEvents.Length; i++) {
			buttonEvents[i].enabled = false;
		}
		
		if(m){
			if(activeOtherTime > 0)
				StartCoroutine(EnableFadeIn(m));
			else
				m.IniFadeIn();
		}

		if(disableTime >0){
			StartCoroutine(DisableFadeOut());
		}else{
			Disable();
		}	
	}

	IEnumerator EnableFadeIn(Menu menuFadeIn){
		yield return new WaitForSecondsRealtime(activeOtherTime);
		menuFadeIn.IniFadeIn();
	}

	IEnumerator DisableFadeOut(){
		yield return new WaitForSecondsRealtime(disableTime);
		Disable();
	}
}
