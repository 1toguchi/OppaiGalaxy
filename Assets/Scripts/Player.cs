using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    //スピード。上下動はゆっくり重め。
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 1.0F;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
    //十字キーで上下左右。左右は逆。
    float h = horizontalSpeed * Input.GetAxis("Horizontal");
    float v = verticalSpeed * Input.GetAxis("Vertical");
    transform.Translate(-h, v, 0);

    //マウスで動く。微調整が必要なんじゃないかな。
    float hh = horizontalSpeed * Input.GetAxis("Mouse X");
    float vv = verticalSpeed * Input.GetAxis("Mouse Y");
    transform.Translate(-hh,vv,0);
    }
}
