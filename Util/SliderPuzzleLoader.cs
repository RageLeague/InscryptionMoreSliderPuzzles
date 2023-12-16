using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using DiskCardGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;
using GBC;

namespace MoreSliderPuzzles.Util
{
    public static class SliderPuzzleLoader
    {
        public static List<SliderPuzzleInfo> LoadAllPuzzles()
        {
            List<SliderPuzzleInfo> allPuzzles = new();
            foreach (string file in Directory.EnumerateFiles(Paths.PluginPath, "*.pdef", SearchOption.AllDirectories))
            {
                if (file.EndsWith("_example.pdef") || file == null)
                {
                    continue;
                }
                else
                {

                    string data = File.ReadAllText(file);
                    try
                    {
                        allPuzzles.Add(SliderPuzzleUtil.ConvertToPuzzle(data));
                        Console.Write("Loaded " + file + " puzlle");
                    }
                    catch { }
                }
            }
            if (Plugin.Randomized.Value == true)
            {
                Random rng = new Random();
                int n = allPuzzles.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    SliderPuzzleInfo value = allPuzzles[k];
                    allPuzzles[k] = allPuzzles[n];
                    allPuzzles[n] = value;
                }
                return allPuzzles;
            } else
            {
                return allPuzzles;
            }
        }
    }
}