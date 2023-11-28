using DiskCardGame;
using GBC;
using HarmonyLib;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MoreSliderPuzzles.Patches
{

    [HarmonyPatch]
    internal class PixelSliderPuzzleSliderPatch
    {
        [HarmonyPostfix, HarmonyPatch(typeof(PixelSliderPuzzleSlider), nameof(PixelSliderPuzzleSlider.DisplaySliderInfo))]
        private static void DisplayStatIconsOnSliders(PixelSliderPuzzleSlider __instance)
        {
            // if the slider's card info has a special stat icon, hide the corresponding stat texts
            // update/add the stat icon objects
            if (__instance.cardInfo.SpecialStatIcon != 0)
            {
                StatIconInfo iconInfo = StatIconInfo.GetIconInfo(__instance.cardInfo.SpecialStatIcon);

                __instance.attackText.SetShown(!iconInfo.appliesToAttack);
                __instance.healthText.SetShown(!iconInfo.appliesToHealth);

                UpdatePixelStatIcons(__instance, iconInfo.pixelIconGraphic, iconInfo.appliesToAttack, iconInfo.appliesToHealth);
            }
        }
        private static void UpdatePixelStatIcons(PixelSliderPuzzleSlider instance, Sprite sprite, bool applyToAttack, bool applyToHealth)
        {
            GameObject attackObj = instance.attackText.transform.parent.Find("PixelSliderAttackStatIcon")?.gameObject;
            GameObject healthObj = instance.healthText.transform.parent.Find("PixelSliderHealthStatIcon")?.gameObject;

            if (attackObj == null)
            {
                GameObject abilityObj = instance.transform.Find("Stats/PixelAbilityIcons/AbilityIcons_1").gameObject;

                attackObj = SerializedUnityObject.Instantiate(abilityObj, abilityObj.transform.parent);
                attackObj.name = "PixelSliderAttackStatIcon";
                attackObj.transform.localPosition = new(-0.12f, -0.125f, 0f);
                attackObj.SetActive(false);

                healthObj = SerializedUnityObject.Instantiate(abilityObj, abilityObj.transform.parent);
                healthObj.name = "PixelSliderHealthStatIcon";
                healthObj.transform.localPosition = new(0.12f, -0.125f, 0f);
                healthObj.SetActive(false);
            }

            attackObj.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            healthObj.GetComponentInChildren<SpriteRenderer>().sprite = sprite;

            attackObj.SetActive(applyToAttack);
            healthObj.SetActive(applyToHealth);
        }
    }
}