using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[System.Serializable]
public class Connection{


	public Menu menuOrigin;
	public Menu menuTarget;
	public int buttonOut;
	public int nodeOut;
	public int nodeIn;

	public GUIStyle style;

	public Connection(int menuOut, int buttonOut, int menuIn, Menu menuOrigin, Menu menuTarget, GUISkin skin){
		
		this.menuOrigin = menuOrigin;
		this.menuTarget = menuTarget;
		this.nodeOut = menuOut;
		this.buttonOut = buttonOut;
		this.nodeIn = menuIn;
		
		this.style = skin.button;
		#if UNITY_EDITOR
		NodeEditor.RemoveDuplicateConnectionOut(this);
		#endif
    }
	#if UNITY_EDITOR
    public void Draw(MenuDesign menu){
		
		if(!(menu.nodes.Count > nodeIn) ||  !(menu.nodes.Count > nodeOut) || !(menu.nodes[nodeOut].outPoint.Count > buttonOut)){
			NodeEditor.RemoveConnection(this);
		  	return;
		}
		Rect rectIn = menu.nodes[nodeIn].inPoint.rect;
		Rect rectOut = menu.nodes[nodeOut].outPoint[buttonOut].rect;
		Color shadowCol = new Color(0, 0, 0, 0.3f);
		Rect shadowrect = rectIn;
		Rect shadowrectOut = rectOut;
		shadowrect.x+=3;
		shadowrect.y+=3;
		shadowrectOut.x+=3;
		shadowrectOut.y+=3;
		//for (int i = 0; i < 3; i++){ // Draw a shadow
			Handles.DrawBezier(
			shadowrect.center,
           	shadowrectOut.center,
            shadowrect.center + Vector2.left * 50f,
           	shadowrectOut.center - Vector2.left * 50f,			
 			shadowCol, null, NodeEditor.lineWidht*1.5f);
		//}
    	Handles.DrawBezier(
       	rectIn.center,
       	rectOut.center,
        rectIn.center + Vector2.left * 50f,
        rectOut.center - Vector2.left * 50f,
		NodeEditor.lineColor,
        null,
        NodeEditor.lineWidht
        );
	
        Vector3 btnPos = (rectIn.center + rectOut.center) * 0.5f;
		float btnSize = 24f;
		if (GUI.Button (new Rect (btnPos.x - (btnSize* 0.5f), btnPos.y - (btnSize* 0.5f), btnSize, btnSize), "╳", style)) {
			NodeEditor.RemoveConnection (this);
		}
    }
	#endif
}