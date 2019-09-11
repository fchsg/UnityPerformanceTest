using System.Text;
using UnityEngine;

namespace Utils
{
    public static class DeviceInfo 
    {
        public static string Info()
        {
            var sb = new StringBuilder();
            sb.Append($"UnityVersion:{Application.unityVersion} \n");
            sb.Append($"Device:{SystemInfo.deviceModel} \n");
            sb.Append($"CPU:{SystemInfo.processorType} \n");
            sb.Append($"GPU:{SystemInfo.graphicsDeviceName} \n");
            sb.Append($"MEMORY:{SystemInfo.systemMemorySize} \n");
            
            return sb.ToString();
        }
    }
}
