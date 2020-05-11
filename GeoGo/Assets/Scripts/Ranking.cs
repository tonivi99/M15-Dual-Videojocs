using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    public Text DistanceText;
    public string[] items;

    public string[] fibucle;

    public GameObject panel;

    int posicio = 0;

    string createGrupUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/id_grup.php";

    void Start()
    {
        StartCoroutine(IECert());
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
        string nom = "";
        posicio = 0;
        int result = 0;
        Boolean proba = true;

        while (i < result || proba == true)
        {
            proba = false;
            WWWForm form = new WWWForm();
            form.AddField("input_NomGrup", grup);
            WWW itemsData = new WWW("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/rankingbe.php", form);
            yield return itemsData;
            string itemsDataString = itemsData.text;
            items = itemsDataString.Split(';');
            fibucle = itemsDataString.Split('-');
            nom = GetDataValue(items[i], "ID_USU:");
            string contador = GetDataValue(items[i], "CONTADOR:");
            string bucle = GetDataValue(fibucle[0], "bucle:");
            result = Int32.Parse(bucle);
            StartCoroutine(CrearText(nom, contador));
            i++;
        }
    }

        IEnumerator CrearText(string username, string cont)
        {
            WWWForm form = new WWWForm();
            form.AddField("id_usuari", username);
            WWW www = new WWW("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/retornarnom.php", form);
            yield return www;
            string nomusuari = www.text.Trim();
            Text tempTextBox = Instantiate(DistanceText, new Vector3(461, 1431 - posicio, 0), Quaternion.identity) as Text;
            tempTextBox.transform.SetParent(panel.transform, true);
            tempTextBox.text = nomusuari + ": ................. " + cont;
            posicio = 150;
        }
    
}
