using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField]
    private Animation loading;
    private ReadySources readySources;
    private PlatesManager platesManager;
    private void Awake()
    {
        readySources = GameObject.Find("ReadySources").GetComponent<ReadySources>();
        platesManager = GameObject.Find("Plates").GetComponent<PlatesManager>();
    }
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            UIButton item = transform.GetChild(i).GetComponent<UIButton>();
            AddOnClickEvent(this, item, "SelectKnife", item.gameObject.name, typeof(string));
        }
    }

    private void SelectKnife(string type)
    {
        print(type);
        switch (type)
        {
            case "knife1":
                Cook();
                break;
            case "knife2":
                Cook();
                break;
            case "knife3":
                Cook();
                break;
        }
    }

    public void AddOnClickEvent(MonoBehaviour target, UIButton btn, string method, object value, Type type)
    {
        EventDelegate onClickEvent = new EventDelegate(target, method);
        EventDelegate.Parameter param = new EventDelegate.Parameter();
        param.value = value;
        param.expectedType = type;
        onClickEvent.parameters[0] = param;
        EventDelegate.Add(btn.onClick, onClickEvent);
    }

    private void Cook()
    {
        if (!readySources.CheckMaterials() || platesManager.CheckSushi())
            return;
        
        loading.gameObject.SetActive(true);
        loading.Play();
        Invoke("CompleteMaterial", 2.0f);
    }

    private void CompleteMaterial()
    {
        loading.gameObject.SetActive(false);
        readySources.selectedMaterial.mainTexture = null;
        readySources.selectedMaterial.enabled = false;
        platesManager.Getsushi();
    }
}
