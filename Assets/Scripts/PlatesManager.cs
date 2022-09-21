using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesManager : MonoBehaviour
{
    [System.NonSerialized]
    public List<GameObject> sushis = new List<GameObject>();
    private List<Transform> sushi_buffers = new List<Transform>();
    public Transform[] plates;
    private bool isSushi = false;

    private void Start()
    {
        Getsushis();
    }

    // get non-actived sushi
    public void Getsushi()
    {
        Getsushis();

        foreach (GameObject sushi in sushis)
        {
            if (!sushi.activeSelf)
            {
                sushi.GetComponent<SushiInfor>().materialtype = GlobalInfo.materialTypes;
                sushi.GetComponent<UISprite>().spriteName = GlobalInfo.materialTypes.ToString();
                sushi.SetActive(true);
                break;
            }
        }
    }

    // get sushis 
    private void Getsushis()
    {
        int count = 0;
        sushis.Clear();
        sushi_buffers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform item = transform.GetChild(i);
            if (item.tag == "sushi")
                sushi_buffers.Add(item);
        }

        for (int i = 0; i < sushi_buffers.Count; i++)
        {
            for (int j = 0; j < sushi_buffers.Count; j++)
            {
                int index = int.Parse(sushi_buffers[j].Find("index").GetComponent<UILabel>().text);
                if (count == index)
                {
                    count++;
                    sushis.Add(sushi_buffers[j].gameObject);
                    break;
                }
            }
        }
    }

    public bool CheckSushi()
    {
        foreach (var item in sushis)
        {
            if (!item.activeSelf)
            {
                isSushi = false;
                break;
            }
            else
                isSushi = true;
        }
        return isSushi;
    }

    // replace sushis
    public void ReplaceSushis(int plateIndex, int sushiIndex)
    {
        Getsushis();
        //if (!sushis[plateIndex].activeSelf)
        //{
        //    print("有" + sushis[plateIndex].transform.Find("index").GetComponent<UILabel>().text);
        //}
        // two sushi are able to combine?
        if (RuleManager.Instance.CheckRule(sushis[sushiIndex].GetComponent<SushiInfor>().materialtype,
            sushis[plateIndex].GetComponent<SushiInfor>().materialtype))
        {
            sushis[plateIndex].GetComponent<SushiInfor>().materialtype = GlobalInfo.MaterialType.none;
            sushis[sushiIndex].SetActive(false);
            sushis[plateIndex].GetComponent<UISprite>().spriteName = RuleManager.Instance.combineSushi.ToString();
            foreach (GlobalInfo.MaterialType item in RuleManager.Instance.all_sushis)
            {
                if (item.ToString() == RuleManager.Instance.combineSushi.ToString())
                {
                    sushis[plateIndex].GetComponent<SushiInfor>().materialtype = item;
                    break;
                }
            }
        }
        else
        {
            sushis[sushiIndex].transform.Find("index").GetComponent<UILabel>().text = plateIndex.ToString();
            sushis[plateIndex].transform.Find("index").GetComponent<UILabel>().text = sushiIndex.ToString();
        }

        foreach (GameObject sushi in sushis)
        {
            int index = int.Parse(sushi.transform.Find("index").GetComponent<UILabel>().text);
            sushi.transform.localPosition = new Vector3(plates[index].localPosition.x,
                plates[index].localPosition.y + 10, 0);
        }
    }
}
