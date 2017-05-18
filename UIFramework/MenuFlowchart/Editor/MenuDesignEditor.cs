using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;

[CustomEditor(typeof(MenuDesign))]
public class MenuDesignEditor : Editor {

	private MenuDesign m;
//	private bool collapsed; 
//	private string[] menus;
//	private string[] buttonsNames;
//	private Rect rectLabel,rectVar;
//
//	private ReorderableList list;
//
//    private void OnEnable() {
//        list = new ReorderableList(serializedObject, 
//                serializedObject.FindProperty("connections"), 
//                true, true, true, true);
//		list.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
//		    var element = list.serializedProperty.GetArrayElementAtIndex(index);
//		    rect.y += 2;
//			
//			UpdateMenus();
//			rectLabel = new Rect(rect.x, rect.y, 120, EditorGUIUtility.singleLineHeight);
//			rectVar = new Rect(rect.x + 120 , rect.y, rect.width - 120, EditorGUIUtility.singleLineHeight);
//
//			EditorGUI.LabelField(rectLabel,"Name");
//		    EditorGUI.PropertyField(rectVar,element.FindPropertyRelative("name"), GUIContent.none);			
//
//			RectAddY();
//			SerializedProperty menuOrigin = element.FindPropertyRelative("menuOut");
//			EditorGUI.LabelField(rectLabel,"Origin");
//			menuOrigin.intValue = EditorGUI.Popup(rectVar, menuOrigin.intValue, menus);
//
//			UpdateButtonName(index);
//
//			RectAddY();
//			SerializedProperty idButton = element.FindPropertyRelative("buttonOut");
//			EditorGUI.LabelField(rectLabel,"Button");
//			idButton.intValue = EditorGUI.Popup(rectVar, idButton.intValue, buttonsNames);
//
//			RectAddY();
//			SerializedProperty menuTarget = element.FindPropertyRelative("menuIn");
//			EditorGUI.LabelField(rectLabel,"Target");
//			menuTarget.intValue = EditorGUI.Popup(rectVar, menuTarget.intValue, menus);
//		};
//
//		list.drawHeaderCallback = (Rect rect) => {  
//   			EditorGUI.LabelField(rect, "Connections");
//		};
//		list.elementHeight = 100;
//    }
//
//	void RectAddY(){
//		rectLabel.y += 20;
//		rectVar.y+=20;
//	}
//
//	void UpdateButtonName(int index){
//		buttonsNames = new string[m.nodes[m.connections[index].menuOut].menu.transitionButtons.Length];
//		for (int j = 0; j < buttonsNames.Length; j++) {
//			buttonsNames[j] = m.nodes[m.connections[index].menuOut].menu.transitionButtons[j].name;
//		}
//		if(buttonsNames.Length <=0){
//			buttonsNames = new string[]{"Null"};
//		}
//	}
//
//	void UpdateMenus(){
//		menus = new string[m.nodes.Count];
//		for (int i = 0; i < menus.Length; i++) {
////			if(m.menuPrefabs[i] != null)
////				menus[i] = m.menuPrefabs[i].name;
////			else
////				menus[i] = "Null";
//			menus[i] = m.nodes[i].menu.name;
//		}
//	}
	
	public override void OnInspectorGUI (){
		m = (MenuDesign)target;
		base.OnInspectorGUI ();
		if(GUILayout.Button("Create New")){
			m.nodes.Clear();
		}
		if(GUILayout.Button("Open Editor")){
			NodeEditor.OpenWindow(m);
		}
//		serializedObject.Update();
//        list.DoLayoutList();
//        serializedObject.ApplyModifiedProperties();
	}
}
