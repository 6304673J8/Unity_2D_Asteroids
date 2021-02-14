using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Borders {
    public float upperBorder, bottomBorder, leftBorder, rightBorder;
}
public class ToroidalBehaviour : MonoBehaviour
{
    public Borders borders;
    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var x = transform.position.x;
        var y = transform.position.y;

        if (x > borders.rightBorder) {
            pos.x = borders.leftBorder;
            transform.position = pos;
        }
        if (x < borders.leftBorder){
            pos.x = borders.rightBorder;
            transform.position = pos;
        }

        if (y > borders.upperBorder) { 
            pos.y = borders.bottomBorder;
            transform.position = pos;
        }
        if (y < borders.bottomBorder) {
            pos.y = borders.upperBorder;
            transform.position = pos;
        }
    }
}
