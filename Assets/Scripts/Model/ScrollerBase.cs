using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerBase : MonoBehaviour {

    private const int SHOW_MORE_COUNT = 4;//多加载的数目，一般为偶数

    public bool m_IsHorizon;
    private float itemSize;
    private float seeSize;
    private int seeCount;
    private int totalCount;
    private GameObject itemPrefab;

    private GameObject content;
    private RectTransform contentRT;

    private int curIndex;
    private int exitCount;
    private List<GameObject> itemObjList;
    private int finalCount;

    private int desIndex;

    public virtual void Init(bool _isHorizon, float _itemSize, float _seeSize, int _totalCount, GameObject _itemPrefab)
    {
        m_IsHorizon = _isHorizon;
        itemSize = _itemSize;
        seeSize = _seeSize;
        seeCount = Mathf.CeilToInt(seeSize / itemSize);
        itemPrefab = _itemPrefab;
        totalCount = _totalCount;

        content = GameObject.Find("Content");
        contentRT = content.GetComponent<RectTransform>();
        if(m_IsHorizon)
            contentRT.sizeDelta = new Vector2(itemSize * totalCount, 0);
        else
            contentRT.sizeDelta = new Vector2(0, itemSize * totalCount);

        curIndex = 0;
        exitCount = seeCount + SHOW_MORE_COUNT;
        finalCount = Mathf.Min(exitCount, totalCount);

        itemObjList = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < finalCount; i++)
        {
            GameObject item = Instantiate(itemPrefab);
            item.transform.SetParent(content.transform);
            item.transform.localScale = Vector3.one;
            if(m_IsHorizon)
                item.transform.localPosition = new Vector3(itemSize * i, 0, 0);
            else
                item.transform.localPosition = new Vector3(0, -itemSize * i, 0);

            itemObjList.Add(item);
            InitItem(item, i);
            RefreshItem(item, i);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (m_IsHorizon)
            RefreshHorizon();
        else
            RefreshVertical();
	}

    private void RefreshHorizon()
    {
        if(contentRT.localPosition.x < - (itemSize * (curIndex + SHOW_MORE_COUNT / 2)))
        {
            ResetPos(curIndex % finalCount, true);
            curIndex++;
        }
        else if(contentRT.localPosition.x > - (itemSize*(curIndex + 1)))
        {
            if (curIndex < 1)
                return;
            
            ResetPos((curIndex + finalCount - 1) % finalCount, false);
            curIndex--;
        }
    }

    private void RefreshVertical()
    {
        if (contentRT.localPosition.y > (itemSize * (curIndex + SHOW_MORE_COUNT / 2)))
        {
            ResetPos(curIndex % finalCount, true);
            curIndex++;
        }
        else if (contentRT.localPosition.y < (itemSize * (curIndex + 1)))
        {
            if (curIndex < 1)
                return;

            ResetPos((curIndex + finalCount - 1) % finalCount, false);
            curIndex--;
        }
    }

    private void ResetPos(int sourceIndex, bool isTail)
    {
        desIndex = isTail ? curIndex + exitCount : curIndex - 1;
        if (desIndex >= totalCount)
            return;

        if(m_IsHorizon)
            itemObjList[sourceIndex].transform.localPosition = new Vector3(desIndex * itemSize, 0,0);
        else
            itemObjList[sourceIndex].transform.localPosition = new Vector3(0, -desIndex * itemSize, 0);


        if (desIndex < totalCount)
            RefreshItem(itemObjList[sourceIndex], desIndex);
    }

    //自定义
    public virtual void InitItem(GameObject obj, int dataIndex)
    {

    }

    public virtual void RefreshItem(GameObject obj, int dataIndex)
    {

    }
}
