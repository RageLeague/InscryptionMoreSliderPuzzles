using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BepInEx;
using DiskCardGame;
using GBC;

namespace MoreSliderPuzzles.Util
{
    public static class SliderPuzzleLoader
    {
        public static List<SliderPuzzleInfo> LoadAllPuzzles()
        {
            List<SliderPuzzleInfo> allPuzzles = new List<SliderPuzzleInfo>();
            foreach (string file in Directory.EnumerateFiles(Paths.PluginPath, "*.pdef", SearchOption.AllDirectories))
            {
                string data = File.ReadAllText(file);
                try
                {
                    allPuzzles.Add(SliderPuzzleUtil.ConvertToPuzzle(data));
                } 
                catch {}
            }
            return allPuzzles;
        }
    }
}
