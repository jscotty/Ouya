﻿#if UNITY_ANDROID && !UNITY_EDITOR

using System;
using UnityEngine;

namespace com.unity3d.player
{
    public class UnityPlayer
    {
        private const string LOG_TAG = "UnityPlayer";
        private static IntPtr _jcUnityPlayer = IntPtr.Zero;
        private static IntPtr _jfCurrentActivity = IntPtr.Zero;

        static UnityPlayer()
        {
            try
            {
                {
                    string strName = "com/unity3d/player/UnityPlayer";
                    _jcUnityPlayer = AndroidJNI.FindClass(strName);
                    if (_jcUnityPlayer != IntPtr.Zero)
                    {
                        Debug.Log(string.Format("Found {0} class", strName));
                    }
                    else
                    {
                        Debug.LogError(string.Format("Failed to find {0} class", strName));
                        return;
                    }
                }

                {
                    string strField = "currentActivity";
                    _jfCurrentActivity = AndroidJNI.GetStaticFieldID(_jcUnityPlayer, strField, "Landroid/app/Activity;");
                    if (_jfCurrentActivity != IntPtr.Zero)
                    {
                        Debug.Log(string.Format("Found {0} field", strField));
                    }
                    else
                    {
                        Debug.LogError(string.Format("Failed to find {0} field", strField));
                        return;
                    }
                }
            }
            catch (System.Exception)
            {
                Debug.LogError("Exception finding UnityPlayer class");
            }
        }

        public static IntPtr currentActivity
        {
            get
            {
                if (_jcUnityPlayer == IntPtr.Zero)
                {
                    Debug.LogError("_jcUnityPlayer is not initialized");
                    return IntPtr.Zero;
                }
                if (_jfCurrentActivity == IntPtr.Zero)
                {
                    Debug.LogError("_jfCurrentActivity is not initialized");
                    return IntPtr.Zero;
                }

                IntPtr result = AndroidJNI.GetStaticObjectField(_jcUnityPlayer, _jfCurrentActivity);
                if (result == IntPtr.Zero)
                {
                    Debug.LogError("Failed to get current activity");
                }
                return result;
            }
        }
    }
}

#endif