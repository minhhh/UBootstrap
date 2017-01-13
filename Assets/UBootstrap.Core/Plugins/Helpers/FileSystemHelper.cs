﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

namespace UBootstrap
{
    public static class FileSystemHelper
    {
        #if UNITY_EDITOR
        /// <summary>
        /// Makes a folder in Assets folder
        /// </summary>
        /// <param name="path">The path inside Assets</param>
        public static void MakeFolderInAssets (string path)
        {
            string[] folderNames = path.Split ('/');
            string currentPath = "Assets";
            for (int i = 0; i < folderNames.Length; i++) {
                string folderPath = Path.Combine (currentPath, folderNames [i]);
                if (!Directory.Exists (folderPath)) {
                    AssetDatabase.CreateFolder (currentPath, folderNames [i]);
                }
                currentPath = folderPath;
            }
        }
        #endif
    }


}
