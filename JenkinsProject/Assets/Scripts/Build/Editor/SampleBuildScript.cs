using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Build
{
    public static class SampleBuildScript
    {


        /// <summary>
        /// Android�r���h
        /// </summary>
        public static void BuildAndroid()
        {
            // Android�ŕK�v�ȏ������s��

            Build(BuildTarget.Android, Path.Combine(Directory.GetCurrentDirectory(), "Build/Android/Hoge.apk"));
        }

        /// <summary>
        /// iOS�r���h
        /// </summary>
        public static void BuildIOS()
        {
            // iOS�ŕK�v�ȏ������s��
            Build(BuildTarget.iOS, Path.Combine(Directory.GetCurrentDirectory(), "Build/iOS/Hoge.ipa"));

        }

        /// <summary>
        /// Windows�r���h
        /// </summary>
        public static void BuildWindows()
        {
            // Windows�ŕK�v�ȏ������s��
            Build(BuildTarget.StandaloneWindows64, Path.Combine(Directory.GetCurrentDirectory(), "Build/Windows/Hoge.exe"));
        }

        private static void BuildWindowsWithOption()
        {
            var args = System.Environment.GetCommandLineArgs();
            for (int index = 0; index < args.Length; index++)
            {
                if (args[index].Contains("defineSymbols"))
                {
                    var defineSymbols = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Standalone);
                    defineSymbols += ";" + args[index + 1];
                    PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, defineSymbols);
                    index++;
                    continue;
                }
                Debug.Log($"�ǂ݉�����Ȃ������ł��B argument : {args[index]}");
            }
        }

        /// <summary>
        /// �r���h
        /// </summary>
        /// <param name="buildTarget">�^�[�Q�b�gPlatform</param>
        /// <param name="buildPath">�r���h�p�X</param>
        private static void Build(BuildTarget buildTarget, string buildPath)
        {
            // �v���b�g�t�H�[����؂�ւ���
            EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);

            var buildScenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray();

            // �A�v�����r���h����
            BuildPipeline.BuildPlayer(buildScenes, buildPath, buildTarget, BuildOptions.None);
        }
    }
}