using System.Collections;
using System.Reflection;
using BepInExHelper;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Patch
{
    public static void Initialize()
    {
        Harmony.CreateAndPatchAll(typeof(Patch));
    }
    // [HarmonyPostfix]
    // [HarmonyPatch(typeof(IconImageLoader), "CreateCharacterIcon")]
    // public static void CreateCharacterIconChange(Texture2D texture, string id, Transform parent)
    // {
    //     var newIcon = parent.GetChild(parent.childCount - 1);
    //     newIcon.name = id;
    // }
    // [HarmonyPostfix]
    // [HarmonyPatch(typeof(IconImageLoader), "CreateStoryIcon")]
    // public static void CreateStoryIconChange(Texture2D texture, string storyId, Transform parent)
    // {
    //     var newIcon = parent.GetChild(parent.childCount - 1);
    //     newIcon.name = storyId;
    // }
    // [HarmonyPostfix]
    // [HarmonyPatch(typeof(IconImageLoader), nameof(IconImageLoader.ShowLayer))]
    // public static void ShowLayerChange(GameObject target)
    // {
    //     ModConfig.Log.LogInfo(target.name);
    //     SortList();
    // }
    // public static void SortList()
    // {
    //     var loader = UnityEngine.Object.FindObjectOfType<IconImageLoader>();
    //     // P(loader.mylistLayer.gameObject);
    //     P(loader.recollectionContent.gameObject);
    //     P(loader.srecollectionContent.gameObject);
    //     P(loader.newContent.gameObject);
    //     P(loader.characterContent.gameObject);
    //     P(loader.summonContent.gameObject);
    // }
    // public static void P(GameObject gameObject)
    // {
    //     if (!gameObject.activeSelf)
    //     {
    //         return;
    //     }
    //     for (int i = 0; i <  gameObject.transform.childCount; i++)
    //     {
    //         var child = gameObject.transform.GetChild(i);
    //         string roleId = child.name;
    //         bool isLove = playerDataList.list.Contains(roleId);
    //         Like.AddLoveImageUI(child.gameObject, ModConfig.LoveIconPath.Value, isLove);
    //         if (isLove)
    //         {
    //             child.SetAsFirstSibling();
    //         }
    //     }
    // }
}