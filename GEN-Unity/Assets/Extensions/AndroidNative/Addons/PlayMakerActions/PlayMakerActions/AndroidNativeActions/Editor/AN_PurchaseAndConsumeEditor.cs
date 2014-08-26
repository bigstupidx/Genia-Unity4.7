using UnityEngine;
using System.Collections;
using UnityEditor;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;

[CustomActionEditor(typeof(AN_PurchaseAndConsume))]
public class AN_PurchaseAndConsumeEditor : CustomActionEditor {

	private int index = 0;

	public override void OnEnable() {
		AN_PurchaseAndConsume action = target as AN_PurchaseAndConsume;
		if(AndroidNativeSettings.Instance.InAppProducts.Contains(action.ProductID)) {
			index = AndroidNativeSettings.Instance.InAppProducts.IndexOf(action.ProductID);
		}

	}
	
	// Update is called once per frame
	public override bool OnGUI() {
		// If you need to reference the action directly:
		AN_PurchaseAndConsume action = target as AN_PurchaseAndConsume;
		
		// You can draw the full default inspector.
		

		bool isDirty = DrawDefaultInspector();
		
		// Or draw individual controls
		
		GUILayout.Label("Choose in-app product.", EditorStyles.label);
		GUILayout.Label("Yuo can purchase only product with is defined under ", EditorStyles.label);
		GUILayout.Label("Window -> Android Native -> Settings:", EditorStyles.label);

		if(AndroidNativeSettings.Instance.InAppProducts.Count == 0) {
			EditorGUILayout.HelpBox("No producs added", MessageType.Warning);

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Space();
			if(GUILayout.Button("Add In-App Producs",  GUILayout.Width(120))) {
				AndroidNativeSettings.Instance.ShowStoreKitParams = true;
				Selection.activeObject = AndroidNativeSettings.Instance;
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
		} else {
			index = EditorGUILayout.Popup(index, AndroidNativeSettings.Instance.InAppProducts.ToArray());
			action.ProductID = AndroidNativeSettings.Instance.InAppProducts[index];
		}

		
		return isDirty || GUI.changed;
	}
}
