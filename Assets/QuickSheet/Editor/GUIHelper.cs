///////////////////////////////////////////////////////////////////////////////
using UnityEditor;

///
/// GUIHelper.cs
///
/// (c)2015 Kim, Hyoun Woo
///
///////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public static class GUIHelper {

	public static GUIStyle MakeHeader() {
		GUIStyle headerStyle = new GUIStyle(GUI.skin.label);
		headerStyle.fontSize = 12;
		headerStyle.fontStyle = FontStyle.Bold;

		return headerStyle;
	}
}
