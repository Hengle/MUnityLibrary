using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace MUnityLibrary.Editor.Script
{
    public class CreateScriptEndNameEditAction : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string templeteDirectoryPath)
        {
            CreateScriptAsset("Model", pathName, templeteDirectoryPath);
            CreateScriptAsset("View", pathName, templeteDirectoryPath);
            CreateScriptAsset("Presenter", pathName, templeteDirectoryPath);
        }

        private static void CreateScriptAsset(string domainName, string filePath, string templeteDirectoryPath)
        {
            string baseClassName = Path.GetFileNameWithoutExtension(filePath);
            baseClassName = baseClassName?.Replace(" ", "");

            string templeteRawText = Resources.Load(templeteDirectoryPath + domainName + ".cs").ToString();
            string replacedText = templeteRawText.Replace("#SCRIPTNAME#", baseClassName);
            var encodeing = new UTF8Encoding(true, false);

            string addDomainFilePath = AddDomain(filePath, domainName);
            File.WriteAllText(addDomainFilePath, replacedText, encodeing);

            AssetDatabase.ImportAsset(addDomainFilePath);
            var createdScript = AssetDatabase.LoadAssetAtPath<MonoScript>(addDomainFilePath + domainName);
            ProjectWindowUtil.ShowCreatedAsset(createdScript);
        }

        private static string AddDomain(string filePath, string domainName)
        {
            return filePath.Replace(".cs", domainName + ".cs");
        }
    }
}