///////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

///
/// GoogleMachine.cs
///
/// (c)2013 Kim, Hyoun Woo
///
///////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace UnityEditor {

	/// <summary>
	/// A class for various setting to import google spreadsheet data and generated related script files.
	/// </summary>
	internal class GoogleMachine : BaseMachine {

		[SerializeField]
		public static string generatorAssetPath = "Assets/QuickSheet/GDataPlugin/Tool/";

		[SerializeField]
		public static string assetFileName = "GoogleMachine.asset";

		// excel and google plugin have its own template files, so we need to set the different path
		// when the asset file is created.
		private readonly string gDataTemplatePath = "QuickSheet/GDataPlugin/Templates";

		public string AccessCode = "";

		/// <summary>Note: Called when the asset file is selected.</summary>
		protected new void OnEnable() {
			base.OnEnable();

			TemplatePath = gDataTemplatePath;
		}

		/// <summary>A menu item which create a 'GoogleMachine' asset file.</summary>
		[MenuItem("Assets/Create/QuickSheet/Tools/Goolgle")]
		public static void CreateGoogleMachineAsset() {
			GoogleMachine inst = ScriptableObject.CreateInstance<GoogleMachine>();
			string path = CustomAssetUtility.GetUniqueAssetPathNameOrFallback("New GoogleMachine.asset");
			AssetDatabase.CreateAsset(inst, path);
			AssetDatabase.SaveAssets();
			Selection.activeObject = inst;
		}
	}
}
