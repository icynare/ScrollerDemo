using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScroller : ScrollerBase {

    public override void Init(bool _isHorizon, float _itemSize, float _seeSize, int _totalCount, GameObject _itemPrefab)
    {
        base.Init(_isHorizon, _itemSize, _seeSize, _totalCount, _itemPrefab);
    }

    public override void InitItem(GameObject obj, int dataIndex)
    {
        base.InitItem(obj, dataIndex);
        //Only For Test
        obj.GetComponent<Image>().color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
        RefreshItem(obj, dataIndex);
    }

    public override void RefreshItem(GameObject obj, int dataIndex)
    {
        obj.name = (dataIndex + 1).ToString();
        obj.transform.Find("Text").GetComponent<Text>().text = (dataIndex + 1).ToString();
    }

}
