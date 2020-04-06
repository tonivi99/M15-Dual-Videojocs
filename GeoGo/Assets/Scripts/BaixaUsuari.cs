using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaixaUsuari : MonoBehaviour
{
    string createUserUrl = "http://localhost/flors/baixa_usuari.php";
    //string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/baixa_usuari.php";
    public InputField inputUsernameBaixa;
    public InputField inputGrupBaixa;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void buttonBorrarUsuari(){
        CreateUser(inputUsernameBaixa.text, inputGrupBaixa.text);
    }
    
    public void CreateUser (string username, string grup){
        WWWForm form = new WWWForm();
        form.AddField("usernamePostBaixa",username);
        form.AddField("grupPostBaixa",grup);
        WWW www = new WWW (createUserUrl,form);
    }
}