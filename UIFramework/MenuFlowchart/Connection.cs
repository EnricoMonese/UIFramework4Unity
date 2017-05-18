using System;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Connection{

	//public string name;
	public Menu menuOrigin;
	public Menu menuTarget;
	public int buttonOut;
	public int nodeOut;
	public int nodeIn;		

	public Connection(int menuOut, int buttonOut, int menuIn, Menu menuOrigin, Menu menuTarget){
		
		this.menuOrigin = menuOrigin;
		this.menuTarget = menuTarget;
		this.nodeOut = menuOut;
		this.buttonOut = buttonOut;
		this.nodeIn = menuIn;
		NodeEditor.RemoveDuplicateConnectionOut(this);
    }

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
        if (Handles.Button((rectIn.center + rectOut.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleCap)){
               NodeEditor.RemoveConnection(this);
        }
    }
}