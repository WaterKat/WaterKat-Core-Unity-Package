using UnityEditor;
using UnityEngine;
using System.IO;

namespace WaterKat
{
    public class WaterkatCoreEditorWindow : EditorWindow
    {
        private void OnGUI()
        {
            EditorGUILayout.LabelField("WaterKat Script Templates",EditorStyles.boldLabel);
            EditorGUILayout.LabelField("These are some basic script templates for faster prototyping");
            EditorGUILayout.LabelField("Unity may require you to restard Unity in order to load these templates");
            if (GUILayout.Button("Copy Waterkat Script Templates"))
            {
                string templatePath = "Packages/com.waterkat.core/ScriptTemplates";
                string destinationPath = "Assets/ScriptTemplates";

                if (!AssetDatabase.IsValidFolder(destinationPath)) { AssetDatabase.CreateFolder("Assets", "ScriptTemplates"); }

                string[] assetGUIDS = AssetDatabase.FindAssets("", new string[] { templatePath });
                foreach (var assetGUID in assetGUIDS)
                {
                    string stringPath = AssetDatabase.GUIDToAssetPath(assetGUID);
                    AssetDatabase.CopyAsset(stringPath, destinationPath + stringPath.Substring(stringPath.LastIndexOf('/')));
                }

                AssetDatabase.Refresh();
            }/*
            position = 
                .width = ;*/
        }

        [MenuItem("Window/WaterKat/Core Editor Window")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(WaterkatCoreEditorWindow), true, "Core Editor", true);
        }
    }
}