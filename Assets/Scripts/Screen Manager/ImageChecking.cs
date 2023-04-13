using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChecking : MonoBehaviour
{
    public RawImage img;
    Texture2D myTexture ;
 
    // Use this for initialization
    void Start () {
        // load texture from resource folder
        
        myTexture = Resources.Load ("images/saved") as Texture2D;

        img.texture = myTexture;
        // GameObject rawImage = GameObject.Find ("RawImage");
        // rawImage.GetComponent<RawImage> ().texture = myTexture;
    }
}
