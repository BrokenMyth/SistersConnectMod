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

[BepInPlugin("SistersConnectMod", "SistersConnectMod", "1.0.0.0")]
public class SistersConnectMod : BaseUnityPlugin
{
    public ConfigEntry<float> Colora;
// 在插件启动时会直接调用Awake()方法
    private void Awake()
    {
        
    }

// 在所有插件全部启动完成后会调用Start()方法，执行顺序在Awake()后面；
    private void Start()
    {
        _ = new ModConfig(this, Logger);
        Colora=this.Config.Bind<float>("UI", "ColorA", 0.25f, "透明度");
        Patch.Initialize();
    }

    private bool hasClick = false;
    private bool show = true;
    private float cnt = 0;
  

    GameObject DialogBg = null;
    GameObject 满月_h1 = null;
    GameObject 三日月_h1 = null;
    private void Update()
    {
        // var key2 = new KeyboardShortcut(KeyCode.F5);
        // if (key2.IsDown())
        // {
        //     show = !show;
        //     SetMessageActive(show);
        // }
        if (DialogBg == null)
        {
            GameObject player = GameObject.Find("DialogBg");
            if (player != null)
            {
                DialogBg = player;
            }
        }
        else
        {
            var image=DialogBg.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, Colora.Value);
        }

        if (满月_h1 == null)
        {
            GameObject player = GameObject.Find("满月_h1");
            if (player != null)
            {
                满月_h1 = player;
            }
        }
        else
        {
            // if(Live2dBox.activeSelf)
            //     Live2dBox.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            if (满月_h1.activeSelf)
            {
                满月_h1.transform.position = new Vector3(0, -0.84f ,0);
                满月_h1.transform.localScale = new Vector3( 12 ,12 ,1);
            }
        }
        if (三日月_h1 == null)
        {
            GameObject player = GameObject.Find("三日月_h1");
            if (player != null)
            {
                三日月_h1 = player;
            }
        }
        else
        {
            if (三日月_h1.activeSelf)
            {
                三日月_h1.transform.position = new Vector3(0,-1.93f, 0);
                三日月_h1.transform.localScale = new Vector3(12.5f, 12.5f, 1);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
          
        }
    }
}