using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStyle : ButtonStyleBase {
	
	private Button button;

	[ContextMenu("SetStyle")]
	public override void SetNewStyle(){
		base.SetNewStyle();
		button = gameObject.GetComponentInChildren<Button>(true);
		if(button){
			button.colors = data.colors;
			Button2 b2 = button as Button2;
			if(b2){
				b2.scaleMultiplier = data.scaleMultiplier;
			}
		}
	}
}
