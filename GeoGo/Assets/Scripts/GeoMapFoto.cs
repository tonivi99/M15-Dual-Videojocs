using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GeoMapFoto : MonoBehaviour
{
    private string urlMap= "";

    public RawImage imageMap;
    public Text latitudText;
    public Text longitudText;

    //public penjarfoto penjarfoto;

    public int zoom = 20;

    // Start is called before the first frame update
    void Start()
    {
        //imageMap = gameObject.GetComponent<RawImage>();
        StartCoroutine("GetMap");
        
    }

    public void ZoomInButton()
    {
        zoom++;
        StartCoroutine("GetMap");
    }

    public void ZoomOutButton()
    {
        if (zoom >= 0) zoom--;
        StartCoroutine("GetMap");
    }

    private IEnumerator GetMap()
    {
        Input.location.Start();
        float latitud = Input.location.lastData.latitude;
        yield return latitud;
        float longitud = Input.location.lastData.longitude;
        yield return longitud;

        //urlMap = "http://maps.google.com/maps/api/staticmap?center=" + latitud + "," + longitud + "&markers=color:red%7Clabel:S%" + latitud + "," + longitud + "&zoom" + "&size=512x512" + "&maptype=hybrid&markers=color:red|label:P|" + latitud + "," + longitud + "&type=hybrid&sensor=true?a.jpg";

        //urlMap = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitud + "," + longitud + "&zoom=" + zoom + "&size=512x512" + "&maptype=hybrid&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyDbAnQS5kGc5OCpQrx7wxFBz2Ty7ksFxMg";

        //urlMap = "https://maps.googleapis.com/maps/api/staticmap?center=" + 2.8252776 + "," + 41.9816524 + "&zoom=" + zoom + "&size=512x512" + "&maptype=hybrid&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyDbAnQS5kGc5OCpQrx7wxFBz2Ty7ksFxMg";

        urlMap = "https://maps.googleapis.com/maps/api/staticmap?center=Brooklyn+Bridge,New+York,NY&zoom=13&size=600x300&maptype=roadmap&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyDbAnQS5kGc5OCpQrx7wxFBz2Ty7ksFxMg";


        WWW www = new WWW(urlMap);
        yield return www;

        imageMap.texture = www.texture;
        latitudText.text = "" + latitud;
        longitudText.text = "" + longitud;

    }



}
