using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LoginUsuari : MonoBehaviour
{
    public InputField inputName;
    public InputField inputPassordName;

    public InputField inputGrup;
    private String dataPath = "C:/FotosGeo/arxiusdirectory";


    //public LoginUsuari login;

    public Text TextDeLogin;
    string LoginURL = "http://localhost/flors/login.php";
    //string LoginURL = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/login.php";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void buttonEnviar(){
        StartCoroutine(LoginToDB(inputName.text,inputPassordName.text, inputGrup.text));
        
    }
    IEnumerator LoginToDB(string username, string passwordname, string grup){
        WWWForm form = new WWWForm();
        form.AddField("usernamePost",username);
        form.AddField("passwordPost",passwordname);
        form.AddField("grupPost",grup);
        WWW www = new WWW(LoginURL,form);
        yield return www;
        Debug.Log(www.text);

        if (www.text.Contains("Tot OK !!!")){
            SceneManager.LoadScene("Menu");
            CrearArxiuAlumne(inputName.text,inputPassordName.text, inputGrup.text);

        }
        if(www.text.Contains("Error: Usuari desconegut")){
           // Debug.Log("usuari desconegut");
            TextDeLogin.text = "usuari desconegut";
        }
        if(www.text.Contains("Error: Password incorrecte")){
          //  Debug.Log("password incorrecte");
            TextDeLogin.text = "password incorrecte";
        }

    }
    public void CrearArxiuAlumne(string username, string password, string grup){
        if (!Directory.Exists (dataPath)) {
            Directory.CreateDirectory (dataPath);
        }
        if (!File.Exists ("C:/FotosGeo/arxiusdirectory/nomusuari.txt")) {
            StreamWriter sw1 = System.IO.File.CreateText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
            sw1.Close();
            
        }
        if (!File.Exists ("C:/FotosGeo/arxiusdirectory/password.txt")) {
             StreamWriter sw2 = System.IO.File.CreateText("C:/FotosGeo/arxiusdirectory/password.txt");
            sw2.Close();
        }
        if (!File.Exists ("C:/FotosGeo/arxiusdirectory/grup.txt")) {
             StreamWriter sw3 = System.IO.File.CreateText("C:/FotosGeo/arxiusdirectory/grup.txt");
            sw3.Close();
        }

        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt", username);
        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/password.txt", password);
        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/grup.txt", grup);
    }
}
