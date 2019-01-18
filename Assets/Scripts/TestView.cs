using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestView : MonoBehaviour {

    private MyScroller scroller;

	// Use this for initialization
	void Awake () {

        scroller = transform.Find("Scroll View").GetComponent<MyScroller>();
        scroller.Init(true, 300, 1520, 100, Resources.Load<GameObject>("Prefab/Item"));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
