using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearUsuari : MonoBehaviour
{
    string createUserUrl = "http://localhost/flors/alta_usu.php";
    //string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/alta_usu.php";
    public InputField inputUsername;
    public InputField inputPassword;
    public InputField inputGrup;

    public Text TextDeAltaUsu;



    // Update is called once per frame
     public void buttonRegistrar(){
        CreateUser(inputUsername.text,inputPassword.text,inputGrup.text);
    }
    
    public void CreateUser (string username, string password, string grup){
        WWWForm form = new WWWForm();
        form.AddField("usernamePostAlta",username);
        form.AddField("passwordPostAlta",password);
        form.AddField("grupPostAlta",grup);
        WWW www = new WWW (createUserUrl,form);
    }
}