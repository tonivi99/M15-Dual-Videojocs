using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificacionsAlumne : MonoBehaviour
{

    public Text DistanceText;
    public string[] items;

    public string[] fibucle;

    public GameObject panel;

    int posicio = 0;
    int posicio2 = 0;
    RectTransform rt;

    public GameObject panelDescativar;

    //string createGrupUrl = "http://localhost/flors/id_grup.php";

    void Start()
    {
        StartCoroutine(IECert());
        rt = panel.GetComponent<RectTransform>();
    }

    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    IEnumerator IECert()
    {
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        int i = 0;
        string descripcio = "";
        int result = 0;
        Boolean proba = true;

        while (i < result || proba == true)
        {
            proba = false;
            WWWForm form = new WWWForm();
            form.AddField("input_NomGrup", grup);
            WWW itemsData = new WWW("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/notificacioAlumne.php", form);
            yield return itemsData;
            string itemsDataString = itemsData.text;
            items = itemsDataString.Split(';');
            fibucle = itemsDataString.Split('-');
            descripcio = GetDataValue(items[i], "descripcio:");
            string bucle = GetDataValue(fibucle[0], "bucle:");
            result = Int32.Parse(bucle);
            CrearText(descripcio);
            i++;
        }
    }

        public void CrearText(string desc)
        {
            Text tempTextBox = Instantiate(DistanceText, new Vector3(550, 1431 - posicio, 0), Quaternion.identity) as Text;
            tempTextBox.transform.SetParent(panel.transform, true);
            tempTextBox.text = desc;
            panel.transform.position = new Vector3(540,960 - posicio2,0);
            rt.sizeDelta = new Vector2 (912, 1922 + posicio);
            posicio2 += 200;
            posicio += 400;
        }

        public void desactivarPanel(){
            panelDescativar.SetActive(false);
        }
         public void activarPanel(){
            panelDescativar.SetActive(true);
        }



        //POS Y 761
        //H DELTA 2320
    
}
