using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonController : MonoBehaviour
{
    public TextAsset jsonData;

    // private string url =
        // "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.pixabay.com%2Fphoto%2F2015%2F04%2F23%2F22%2F00%2Ftree-736885__480.jpg&tbnid=9SPhZ2nyEGps3M&vet=12ahUKEwiG6KTTq6H-AhUayKACHXKFDz8QMygAegUIARDbAQ..i&imgrefurl=https%3A%2F%2Fpixabay.com%2Fimages%2Fsearch%2Fnature%2F&docid=Ba_eiczVaD9-zM&w=771&h=480&q=images&ved=2ahUKEwiG6KTTq6H-AhUayKACHXKFDz8QMygAegUIARDbAQ";
    // public RawImage saved;
    public Image saved;
    // public Image img;
    //
    //
    // public string imageUrl = "https://ciihuy.com/wp-content/uploads/2019/03/icon.jpg";
    //  
    // // Start is called before the first frame update
    // void Start()
    // {
    //     StartCoroutine(GetImage(imageUrl));
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //      
    // }
    //  
    // IEnumerator GetImage(string imageUrl)
    // {
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
    //     yield return request.SendWebRequest();
    //     if (request.isNetworkError || request.isHttpError)
    //         Debug.Log(request.error);
    //     else{
    //         Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(request) as Texture2D;
    //         img.sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(0, 0));
    //
    //         // GetComponent<Image>().sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(0, 0));
    //     }
    // }
    // public string url = "https://i.pinimg.com/originals/9e/1d/d6/9e1dd6458c89b03c506b384f537423d9.jpg";
    // public Renderer thisRenderer;
    //
    // // automatically called when game started
    // void Start()
    // {
    //     StartCoroutine(LoadFromLikeCoroutine()); // execute the section independently
    //
    //     // the following will be called even before the load finished
    //     thisRenderer.material.color = Color.red;
    // }
    //
    // // this section will be run independently
    // private IEnumerator LoadFromLikeCoroutine()
    // {
    //     Debug.Log("Loading ....");
    //     WWW wwwLoader = new WWW(url);   // create WWW object pointing to the url
    //     yield return wwwLoader;         // start loading whatever in that url ( delay happens here )
    //
    //     Debug.Log("Loaded");
    //     thisRenderer.material.color = Color.white;              // set white
    //     thisRenderer.material.mainTexture = wwwLoader.texture;  // set loaded image
    // }
    //
    
    // public Image saved;
    //
    // IEnumerator Start () {
    //     WWW www = new WWW(        "https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn.pixabay.com%2Fphoto%2F2015%2F04%2F23%2F22%2F00%2Ftree-736885__480.jpg&tbnid=9SPhZ2nyEGps3M&vet=12ahUKEwiG6KTTq6H-AhUayKACHXKFDz8QMygAegUIARDbAQ..i&imgrefurl=https%3A%2F%2Fpixabay.com%2Fimages%2Fsearch%2Fnature%2F&docid=Ba_eiczVaD9-zM&w=771&h=480&q=images&ved=2ahUKEwiG6KTTq6H-AhUayKACHXKFDz8QMygAegUIARDbAQ"
    //         );
    //     while (!www.isDone)
    //         yield return null;
    //     Debug.Log (www.texture.name);
    //     GameObject rawImage = GameObject.Find ("RawImage");
    //     rawImage.GetComponent<RawImage> ().texture = www.texture;
    //     // saved.texture = www.texture;
    //     jsondata jsn = JsonUtility.FromJson<jsondata>(jsonData.text);
    //     Debug.Log("Country Name: " + jsn.data[0].mainCategoryName);
    //     Debug.Log("Country Name: " + jsn.data[0].mainCategoryImage);
    //     Debug.Log("Country Name: " + jsn.data.Length);
    // }
    [System.Serializable]
    public class JsonData
    {
        public MainMenu[] data;
    }
    [System.Serializable]
    public class MainMenu
    {
        public string mainCategoryName;
        public string mainCategoryImage;
    }
    public JsonData players = new JsonData();

    private void Start()
    {
        JsonData jsn = JsonUtility.FromJson<JsonData>(jsonData.text);
        Debug.Log("Country Name: " + jsn.data[0].mainCategoryName);
        Debug.Log("Country Name: " + jsn.data[0].mainCategoryImage);
        Debug.Log("Country Name: " + jsn.data.Length);
        // saved = jsn.data[0].mainCategoryImage;
        // saved.sprite = jsn.data[0].mainCategoryImage.sprite;
        // UnityWebRequest request = UnityWebRequest.Get(url);
        // saved.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    
    }
}
