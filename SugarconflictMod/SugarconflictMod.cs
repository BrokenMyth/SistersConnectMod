using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[BepInPlugin("SugarconflictMod", "SugarconflictMod", "1.0.0.0")]
public class SugarconflictMod : BaseUnityPlugin
{

// 在插件启动时会直接调用Awake()方法
    private void Awake()
    {
        
    }

// 在所有插件全部启动完成后会调用Start()方法，执行顺序在Awake()后面；
    private void Start()
    {
        _ = new ModConfig(this, Logger);
        Patch.Initialize();
    }

    private bool hasClick = false;
    private bool show = true;
    private float cnt = 0;
    private static List<string> HideList = new List<string>()
    {
        "Dialougebg",
    };
    public static void SetMessageActive(bool active = false)
    {
        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        
        foreach (var go in allObjects)
        {
            if (!HideList.Contains(go.name))
            {
                continue;
            }
            // if (go.name == "Button_Log")
            // {
            //     if (go.transform.parent.gameObject.name == "Button_Mein")
            //     {
            //         continue;
            //     }
            // }
            var image = go?.GetComponent<Image>();
            if (image != null)
            {
                image.enabled = active;
            }
            else
            {
                go?.SetActive(active);
            }
        }
    }
    private void Update()
    {
        // var key2 = new KeyboardShortcut(KeyCode.F5);
        // if (key2.IsDown())
        // {
        //     show = !show;
        //     SetMessageActive(show);
        // }

        if (Input.GetMouseButtonDown(1))
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (var r in results)
            {
                var cell = r.gameObject.GetComponentInParent<ScrollRect>();
                if (cell == null)
                    continue;
                ModConfig.Log.LogInfo(r.gameObject.transform.parent.name);
                
                // if (Patch.idsDict.TryGetValue(cell.gameObject, out var unitId))
                // {
                var name = r.gameObject.transform.parent.name;
                Patch.playerDataList.Click(name);
                Patch.playerDataList.Save();
                Patch.SortList();
                ModConfig.Log.LogInfo(
                    $"[RightClick] UnitId = {name}");
                // }
                break;
            }
        }
    }
}