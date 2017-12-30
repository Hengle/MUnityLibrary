using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace MUnityLibrary.Editor.Script
{
    public class NewScriptForMvp : MonoBehaviour
    {
        private const string ResourcePathOfScriptTemplete = "ScriptTemplete/";

        private const string DefaultAssetName = "NewScript.cs";

        private const string CSharpScriptIconName = "cs Script Icon";

        [MenuItem("Assets/Create/C# Script for MVP", false, 80)]
        public static void CreateCSharpScriptForMvp()
        {
            var icon = EditorGUIUtility.IconContent(CSharpScriptIconName).image as Texture2D;

            var endNameEditAction = ScriptableObject.CreateInstance<CreateScriptEndNameEditAction>() as EndNameEditAction;

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, DefaultAssetName, icon,
                ResourcePathOfScriptTemplete);
        }
    }
}