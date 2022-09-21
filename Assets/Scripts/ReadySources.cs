using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadySources : MonoBehaviour
{
    private bool isMaterial = false;
    private string materialType;
    [System.NonSerialized]
    public UITexture selectedMaterial;
    void Start()
    {
        
    }

    public bool CheckMaterials()
    {
        isMaterial = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<UITexture>().mainTexture != null)
            {
                isMaterial = true;
                selectedMaterial = transform.GetChild(i).GetComponent<UITexture>();
                materialType = selectedMaterial.mainTexture.name;
                Material_tobeCooked(materialType);
                break;
            }
        }
        return isMaterial;
    }

    public void Material_tobeCooked(string material)
    {
        switch (material)
        {
            case "egg":
                GlobalInfo.materialTypes = GlobalInfo.MaterialType.egg;
                break;
            case "salmon":
                GlobalInfo.materialTypes = GlobalInfo.MaterialType.salmon;
                break;
            case "rice":
                GlobalInfo.materialTypes = GlobalInfo.MaterialType.rice;
                break;
        }

    }

}
