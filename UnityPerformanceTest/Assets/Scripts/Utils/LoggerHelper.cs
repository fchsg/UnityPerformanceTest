using UnityEngine;

namespace Utils
{
    public static class LoggerHelper 
    {
        public static void Log(string log)
        {
            var platform = "";
            var unityVersion = Application.unityVersion;

#if UNITY_EDITOR_WIN
            platform = "platform:win";
#elif  !UNITY_EDITOR && UNITY_ANDROID
            platform = "platform:android";
#elif  !UNITY_EDITOR && UNITY_IOS
            platform = "platform:ios";
#endif
            
            Debug.Log($"{unityVersion}_{platform}_{log}");
            
        }
    }
}
