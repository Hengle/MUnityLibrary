﻿namespace MUnityLibrary.OutGame
{
    public class SceneModelBase
    {
        public string SceneName { get; private set; }

        public void SetSceneName(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}