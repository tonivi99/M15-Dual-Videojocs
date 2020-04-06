using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearGrup : MonoBehaviour
{

    public GameObject activarGrupGO;
    string createGrupUrl = "http://localhost/flors/crear_grup.php";
    public InputField inputGrup;
    // Start is called before the first frame update
  public void buttonRegistrar(){
        CreateGrup(inputGrup.text);
    }
    
    public void CreateGrup (string nomGrup){
        WWWForm form = new WWWForm();
        form.AddField("inputNomGrup",nomGrup);
        WWW www = new WWW (createGrupUrl,form);
    }
    public void desactivarGrup(){
        activarGrupGO.SetActive(true);
    }
      public void activarGrup(){
        activarGrupGO.SetActive(false);
        inputGrup.text = "";
    }
}