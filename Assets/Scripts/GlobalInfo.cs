using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour
{
    public enum MaterialType
    {
        none,
        egg,
        salmon,
        rice,
        egg_rice,
        egg_rice_seaweed,
    }
    
    public static MaterialType materialTypes = MaterialType.none;
}
