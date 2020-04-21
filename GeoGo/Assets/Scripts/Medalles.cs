using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medalles : MonoBehaviour
{
    string LoginURL = "http://localhost/flors/medalles.php";

    public GameObject medalla1;
    public GameObject medalla2;
    public GameObject medalla3;
    public GameObject medalla4;
    public GameObject medalla5;
    public GameObject medalla6;



    string nom = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IEMedalles(nom));
    }

    IEnumerator IEMedalles(string username){
        WWWForm form = new WWWForm();
        form.AddField("input_NomJugador",username);
        WWW www = new WWW(LoginURL,form);
        yield return www;
        string punts = www.text;
        string puntsArreglat = punts.Trim();
        Debug.Log(puntsArreglat);
        int IntPunts = System.Int32.Parse(puntsArreglat);
        ActivarMedalles(IntPunts);
    }

    public void ActivarMedalles(int punts){
        if(punts >= 5){
            medalla1.SetActive(false);
        }
        if(punts >= 10){
            medalla2.SetActive(false);
        }
        if(punts >= 15){
            medalla3.SetActive(false);
        }
        if(punts >= 20){
            medalla4.SetActive(false);
        }
        if(punts >= 25){
            medalla5.SetActive(false);
        }
        if(punts >= 30){
            medalla6.SetActive(false);
        }
    }
}