using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherView : MonoBehaviour {

    private MyScroller scroller;

    private void Awake()
    {
        scroller = transform.Find("Scroll View").GetComponent<MyScroller>();
        scroller.Init(false, 300, 1520, 100, Resources.Load<GameObject>("Prefab/ItemV"));
    }
   
}
