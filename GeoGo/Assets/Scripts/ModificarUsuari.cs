using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificarUsuari : MonoBehaviour
{
    string createUserUrl = "http://localhost/flors/modificar_usuari.php";
    //string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/modificar_usuari.php";
    public InputField inputUsernameModificar;
    public InputField inputGrupModificar;
    public InputField inputPasswordModificar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void buttonModificarUsuari(){
        CreateUser(inputUsernameModificar.text, inputGrupModificar.text, inputPasswordModificar.text);
    }
    
    public void CreateUser (string username, string grup, string password){
        WWWForm form = new WWWForm();
        form.AddField("usernamePostModificar",username);
        form.AddField("grupPostModificar",grup);
        form.AddField("passwordPostModificar",password);
        WWW www = new WWW (createUserUrl,form);
    }
}