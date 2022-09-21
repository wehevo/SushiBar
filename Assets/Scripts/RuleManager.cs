using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public static RuleManager Instance { get; private set; }
    public bool isCombine = false;
    public List<GlobalInfo.MaterialType> all_sushis = new List<GlobalInfo.MaterialType>();
    public enum CombinedSushi
    {
        none,
        egg_rice,
        egg_rice_seaweed,
    }
    public CombinedSushi combineSushi = CombinedSushi.none;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        all_sushis.Add(GlobalInfo.MaterialType.none);
        all_sushis.Add(GlobalInfo.MaterialType.egg);
        all_sushis.Add(GlobalInfo.MaterialType.salmon);
        all_sushis.Add(GlobalInfo.MaterialType.rice);
        all_sushis.Add(GlobalInfo.MaterialType.egg_rice);
        all_sushis.Add(GlobalInfo.MaterialType.egg_rice_seaweed);
    }
    public bool CheckRule(GlobalInfo.MaterialType dragSushi, GlobalInfo.MaterialType sushi)
    {
        if (dragSushi.Equals(GlobalInfo.MaterialType.egg) && sushi.Equals(GlobalInfo.MaterialType.rice))
        {
            isCombine = true;
            combineSushi = CombinedSushi.egg_rice;
        }
        else
            isCombine = false;
        return isCombine;
    }
}