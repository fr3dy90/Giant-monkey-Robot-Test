using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackGroundBH : MonoBehaviour
{
    public Color[] myColors;
    
    void Start()
    {
       Texture2D t2d = new Texture2D(2,2, TextureFormat.ARGB32, false);
       int colorIndex = 0;
       for (int y = 0; y < t2d.width; y++)
       {
           for (int x = 0; x < t2d.height; x++)
           {
               t2d.SetPixel(x,y, myColors[colorIndex]);
               colorIndex++;
           }
       }
       t2d.wrapMode = TextureWrapMode.Clamp;
       t2d.filterMode = FilterMode.Trilinear;
       t2d.Apply();
       Sprite sp = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), new Vector2(0, 0));
       GetComponent<Image>().sprite = sp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
