using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    GameObject _followMouseObj;
    // Start is called before the first frame update
    void Start()
    {
        _followMouseObj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _followMouseObj.transform.position = mousePosition - (Vector2.up / 2);
    }
}
//auto format ctrl k -> ctrl d