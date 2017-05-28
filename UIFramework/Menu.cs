using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
namespace UIFramework {
	public class Menu : MonoBehaviour {

		public GameObject firstSelected;

		public Button[] transitionButtons;
		public UnityEvent onFadeIn,onFadeOut;

		public void Disable(){
			gameObject.SetActive(false);
		}

		public void Enable(){
			gameObject.SetActive(true);
			if(EventSystem.current)
				EventSystem.current.SetSelectedGameObject(firstSelected);
		}
	}	
}