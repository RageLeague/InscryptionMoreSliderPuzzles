using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BepInEx;
using DiskCardGame;
using GBC;
using BepInEx.Logging;

namespace MoreSliderPuzzles.Util
{
    public static class SliderPuzzleLoader
    {
        public static List<SliderPuzzleInfo> LoadAllPuzzles()
        {
            List<SliderPuzzleInfo> allPuzzles = new();
            foreach (string file in Directory.EnumerateFiles(Paths.PluginPath, "*.pdef", SearchOption.AllDirectories))
            {
                string data = File.ReadAllText(file);
                try
                {
                    allPuzzles.Add(SliderPuzzleUtil.ConvertToPuzzle(data));
                    Console.Write("Loaded " + file + " puzlle");
                }
                catch { }
            }
            System.Random rng = new System.Random();
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
        }
    }
}
