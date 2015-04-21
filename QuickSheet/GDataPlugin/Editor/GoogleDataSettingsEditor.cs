///////////////////////////////////////////////////////////////////////////////
///
/// GoogleDataSettingsEditor.cs
/// 
/// (c)2013 Kim, Hyoun Woo
///
///////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Editor script class for GoogleDataSettings scriptable object to hide password of google account.
/// </summary>
[CustomEditor(typeof(GoogleDataSettings))]
public class GoogleDataSettingsEditor : Editor 
{
    GoogleDataSettings setting;

    public void OnEnable()
    {
        setting = target as GoogleDataSettings;
    }

    public override void OnInspectorGUI()
    {
        GUI.changed = false;

        GUIStyle headerStyle = GUIHelper.MakeHeader();
        GUILayout.Label("GoogleSpreadsheet Settings", headerStyle);

        EditorGUILayout.Separator();

        // path and asset file name which contains a google account and password.
        GUILayout.BeginHorizontal();
        GUILayout.Label("Setting FilePath: ", GUILayout.Width(110));
        setting.AssetPath = GUILayout.TextField(setting.AssetPath, 120);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Setting FileName: ", GUILayout.Width(110));
        GoogleDataSettings.AssetFileName = GUILayout.TextField(GoogleDataSettings.AssetFileName, 120);
        GUILayout.EndHorizontal();

        EditorGUILayout.Separator();

        if (setting.CheckPath())
        {
            const int LabelWidth = 90;

            // account and passwords setting, this should be specified before you're trying to connect a google spreadsheet.
            GUILayout.BeginHorizontal();
            GUILayout.Label("Account: ", GUILayout.Width(LabelWidth));
            setting.Account = GUILayout.TextField(setting.Account);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Password: ", GUILayout.Width(LabelWidth));
            setting.Password = GUILayout.PasswordField(setting.Password, "*"[0], 25);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Runtime Path: ", GUILayout.Width(LabelWidth));
            setting.RuntimePath = GUILayout.TextField(setting.RuntimePath);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Editor Path: ", GUILayout.Width(LabelWidth));
            setting.EditorPath = GUILayout.TextField(setting.EditorPath);
            GUILayout.EndHorizontal();
        }
        else
        {
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(true, "", "CN EntryError", GUILayout.Width(20));
            GUILayout.BeginVertical();
            GUILayout.Label("", GUILayout.Height(12));
            GUILayout.Label("Correct the path of the GoogleDataSetting.asset file.", GUILayout.Height(20));
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(setting);
            AssetDatabase.SaveAssets();
        }
    }
}
