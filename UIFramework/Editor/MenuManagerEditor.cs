using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(MenuManager))]
public class MenuManagerEditor : Editor {

	string[] buttonsNames;

	private MenuManager m;
	
	public override void OnInspectorGUI (){
		m = (MenuManager)target;
		base.OnInspectorGUI ();
		EditorGUILayout.Space();
		if(m.menus.Count <=0) return;
		GUIStyle style = new GUIStyle(){
			fontSize = 15,
			fontStyle = FontStyle.Bold
			
		};
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Create Menu")){
			m.CreateMenu();
		}
		if(GUILayout.Button("ApplyPrefabs")){
			m.ApplyPrefabs();
		}
		GUILayout.EndHorizontal();
		EditorGUILayout.Space();
		EditorGUILayout.LabelField("Menus",style);
		foreach (var item in m.menus) {
			if(item != null)
			EditorGUILayout.LabelField(item.name);
		}	
	}
}
