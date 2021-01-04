using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public AudioSource audioSource;
    public Text text;
    public Image image1, image2;
    
    void Start()
    {
        var path = System.IO.Directory.GetCurrentDirectory();
        var bundle1 = AssetBundle.LoadFromFile(path + @"\..\ExampleModOutput\unit1");
        foreach (var asset in bundle1.LoadAllAssets())
            Debug.Log($"{asset.name} = {asset.GetType().Name}");
        
        meshRenderer.material = (Material)bundle1.LoadAsset("test");

        var gunship = Instantiate((GameObject) bundle1.LoadAsset("gunship-prefab"));
        gunship.GetComponent<MeshRenderer>().material = (Material) bundle1.LoadAsset("gunship-mat");

        text.font = (Font) bundle1.LoadAsset("thefont");
        image1.sprite = bundle1.LoadAsset<Sprite>("thejpg");
        image2.sprite = bundle1.LoadAsset<Sprite>("thepsd");
        
        var bundle2 = AssetBundle.LoadFromFile(path + @"\..\ExampleModOutput\unit2");
        audioSource.clip = (AudioClip) bundle2.LoadAsset("music");
        audioSource.Play();
    }

}
