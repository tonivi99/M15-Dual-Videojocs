﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enviarGrupranking : MonoBehaviour
{
    string ruta = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/rankingbe.php";
    // Start is called before the first frame update
    void Start()
    {
       string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        EnviarGrup(grup); 
    }
 
   public void EnviarGrup (string nomGrup){
      string url = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/rankingbe.php";
        WWWForm form = new WWWForm();
        form.AddField("inputNomGrup", nomGrup);
        WWW www = new WWW(url, form);
    }
}
