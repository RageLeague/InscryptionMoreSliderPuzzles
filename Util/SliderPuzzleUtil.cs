using System;
using System.Collections.Generic;
using System.Text;
using GBC;
using HarmonyLib;
using UnityEngine;
using DiskCardGame;

namespace MoreSliderPuzzles.Util
{
    public static class SliderPuzzleUtil
    {
        public static SliderPuzzleInfo ConvertToPuzzle(string[,] puzzleDef)
        {
            SliderPuzzleInfo newInfo = ScriptableObject.CreateInstance<SliderPuzzleInfo>();
            for (int i = 0; i < puzzleDef.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleDef.GetLength(1); j++)
                {
                    if (newInfo.tracks[j] == null)
                    {
                        newInfo.tracks[j] = new SliderPuzzleInfo.Track();
                    }
                    if (newInfo.tracks[j].sliders[i] == null)
                    {
                        newInfo.tracks[j].sliders[i] = new SliderPuzzleInfo.Slider();
                    }

                    if (puzzleDef[i, j] == null || puzzleDef[i, j].Length == 0)
                    {
                        newInfo.tracks[j].sliders[i].empty = true;
                        newInfo.tracks[j].sliders[i].positionLocked = false;
                        newInfo.tracks[j].sliders[i].cardInfo = null;
                    }
                    else
                    {
                        newInfo.tracks[j].sliders[i].empty = false;
                        if (puzzleDef[i, j][0] == '!')
                        {
                            newInfo.tracks[j].sliders[i].positionLocked = true;
                            newInfo.tracks[j].sliders[i].cardInfo = CardLoader.GetCardByName(puzzleDef[i, j].Substring(1));
                        }
                        else
                        {
                            newInfo.tracks[j].sliders[i].positionLocked = false;
                            newInfo.tracks[j].sliders[i].cardInfo = CardLoader.GetCardByName(puzzleDef[i, j]);
                        }

                    }
                }
            }
            return newInfo;
        }

        public static string[,] ToStringMatrix(string source, int rows, int cols)
        {
            string[,] result = new string[rows, cols];
            string[] lines = source.Split('\n');
            int i = 0;
            foreach (string line in lines)
            {
                string[] entries = line.Split('|');
                if (entries.Length == 1)
                {
                    continue;
                }
                int j = 0;
                foreach(string entry in entries)
                {
                    string trimmedEntry = entry.Trim();
                    result[i, j] = trimmedEntry;
                    j++;
                    if (j >= cols) break;
                }
                i++;
                if (i >= rows) break;
            }
            return result;
        }

        public static SliderPuzzleInfo ConvertToPuzzle(string puzzleDef)
        {
            return ConvertToPuzzle(ToStringMatrix(puzzleDef, 4, 4));
        }
    }
}
