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
        /// Androidビルド
        /// </summary>
        public static void BuildAndroid()
        {
            // Androidで必要な処理を行う

            Build(BuildTarget.Android, Path.Combine(Directory.GetCurrentDirectory(), "Build/Android/Hoge.apk"));
        }

        /// <summary>
        /// iOSビルド
        /// </summary>
        public static void BuildIOS()
        {
            // iOSで必要な処理を行う
            Build(BuildTarget.iOS, Path.Combine(Directory.GetCurrentDirectory(), "Build/iOS/Hoge.ipa"));

        }

        /// <summary>
        /// Windowsビルド
        /// </summary>
        public static void BuildWindows()
        {
            // Windowsで必要な処理を行う
            Build(BuildTarget.StandaloneWindows64, Path.Combine(Directory.GetCurrentDirectory(), "Build/Windows/Hoge.exe"));
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="buildTarget">ターゲットPlatform</param>
        /// <param name="buildPath">ビルドパス</param>
        private static void Build(BuildTarget buildTarget, string buildPath)
        {
            // プラットフォームを切り替える
            EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);

            var buildScenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray();

            // アプリをビルドする
            BuildPipeline.BuildPlayer(buildScenes, buildPath, buildTarget, BuildOptions.None);
        }
    }
}