using UnityEngine;
using System.Collections.Generic;

namespace MUnityLibrary.Common
{
    /// <inheritdoc />
    /// <summary>
    /// ローカライズ管理
    /// </summary>
    public class LocalizeManager : SingletonMonoBehaviour<LocalizeManager>
    {
        /// <summary>
        /// ローカライズファイルのパス
        /// </summary>
        private const string LocalizationPath = "Localization/";

        /// <summary>
        /// ローカライズファイルのテキスト
        /// </summary>
        private string _localizeTextContent;

        public Dictionary<string, string> Text;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _localizeTextContent = GetLocalizationFile().text;
        }

        /// <summary>
        /// ローカライズファイルの取得
        /// </summary>
        /// <returns>The localization file.</returns>
        private static TextAsset GetLocalizationFile()
        {
            TextAsset localizationFile = (TextAsset) Resources.Load(LocalizationPath + "Localization");

            if (localizationFile != null)
            {
                return localizationFile;
            }
            
            Debug.LogError(LocalizationPath + "には Localization ファイルが存在しません.");
            return null;
        }
    }
}