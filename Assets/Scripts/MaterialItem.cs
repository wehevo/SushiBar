using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItem : MonoBehaviour
{
    public Transform ready_materials;
    
    private void Start()
    {
        GetComponent<UIButton>().onClick.Add(new EventDelegate(SelectMaterial));
    }

    private void SelectMaterial()
    {
        string material = gameObject.name;
        
        for (int i = 0; i < ready_materials.childCount; i++)
        {
            UITexture material_texture = ready_materials.GetChild(i).GetComponent<UITexture>();
            if (material_texture.mainTexture == null || material_texture.enabled == false)
            {
                material_texture.mainTexture = Resources.Load(material) as Texture;
                material_texture.enabled = true;
                break;
            }
        }
    }
}
