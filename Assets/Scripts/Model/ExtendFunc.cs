using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendFunc {

	public static void InitParent(this Transform trans, Transform parent)
    {
        trans.SetParent(parent);
        trans.InitLocalPosition();
        trans.InitScale();
    }

    public static void InitScale(this Transform trans)
    {
        trans.localScale = Vector3.one;
    }

    public static void InitLocalPosition(this Transform trans)
    {
        trans.localPosition = Vector3.zero;
    }

    public static void SetLocalPosX(this Transform trans, float x)
    {
        trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);
    }

    public static void SetLocalPosY(this Transform trans, float y)
    {
        trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
    }

}
