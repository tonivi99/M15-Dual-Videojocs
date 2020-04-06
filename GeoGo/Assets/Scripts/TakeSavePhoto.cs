using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class TakeSavePhoto : MonoBehaviour
{
    public RawImage imageCam;
    public RawImage imageShot;
    private penjarfoto penjarFotografia;

    public RawImage imageShot2;

    public InputField nomPedra;
    private WebCamTexture webCamTexture;
    //    private string fileName = "foto";
    //public string fileName = "foto"; 
    //private string savePath = "/storage/emulated/0/DCIM/Camera/";
    private string savePath = "C:/FotosGeo/";
    private int captureCounter;

    private byte[] bytes;
    private Texture2D snap;


    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        imageCam.texture = webCamTexture;
        webCamTexture.Play();
       
    
    }

    // Update is called once per frame
    public void ButtonSnapShot()
    {
        StartCoroutine("SaveImageCam");
    }

    private IEnumerator SaveImageCam()
    {
        yield return new WaitForEndOfFrame();
        snap = new Texture2D(webCamTexture.width, webCamTexture.height);

        bytes = snap.EncodeToPNG();

        snap.SetPixels(webCamTexture.GetPixels());
        snap.Apply();
        imageShot.texture = snap as Texture;
        imageShot2.texture = snap as Texture;
        
    }
    public void enviarFoto(){

        string username = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        System.IO.File.WriteAllBytes(savePath + nomPedra.text + "_"+ username + "_" + grup /*+ captureCounter.ToString()*/ + ".png", snap.EncodeToPNG());
       // ++captureCounter;
    }
}
