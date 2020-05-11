using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement; 

public class CrearProfessor : MonoBehaviour
{
    //string createUserUrl = "http://localhost/flors/alta_profe.php";
    string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/alta_profe.php";
    public InputField inputUsername;
    public InputField inputPassword;
    public InputField inputGrup;

    public CrearGrup crearGrup = new CrearGrup();
    private String dataPath = "C:/FotosGeo/arxiusdirectory";

    public Text TextDeAltaUsu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void buttonRegistrar(){
        CreateUser(inputUsername.text,inputPassword.text,inputGrup.text);
        crearArxiu(inputUsername.text,inputPassword.text,inputGrup.text);
    }
    
    public void CreateUser (string username, string password, string grup){
        WWWForm form = new WWWForm();
        form.AddField("usernamePostAlta",username);
        form.AddField("passwordPostAlta",password);
        form.AddField("grupPostAlta",grup);
        WWW www = new WWW (createUserUrl,form);

    }

    public void crearArxiu(string username, string password, string grup){
        // Create a string array with the lines of text
        
        if(inputGrup.text == crearGrup.inputGrup.text){
        if (!Directory.Exists (dataPath)) {
            Directory.CreateDirectory (dataPath);
        }
        if (!File.Exists ("C:/FotosGeo/arxiusdirectory/nom.txt")) {
            StreamWriter sw1 = System.IO.File.CreateText("C:/FotosGeo/arxiusdirectory/nomprofessor.txt");
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
                 

        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/nomprofessor.txt", username);
        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/password.txt", password);
        System.IO.File.WriteAllText("C:/FotosGeo/arxiusdirectory/grup.txt", grup);
        SceneManager.LoadScene("Profe");
        } else{
            Debug.Log("grup no correcte");
        }

        
    }
    
}
