using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificacioProfe : MonoBehaviour
{

    string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
    string createUserUrl = "http://localhost/flors/notificacioProfe.php";
    public InputField inputNotificacio;
    // Start is called before the first frame update
   public void buttonNotificacioProfe(){
        enviarNotificacio(inputNotificacio.text,grup);
    }
    
    public void enviarNotificacio (string notificacio,string grup){
        
        WWWForm form = new WWWForm();
        form.AddField("notificacio",notificacio);
        form.AddField("grup",grup);
        WWW www = new WWW (createUserUrl,form);
    }

}
