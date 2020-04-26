using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penjarfoto : MonoBehaviour
{
    public GeoMapFoto geoMapFoto;
    public TakeSavePhoto takeSavePhoto;
    string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/penja_foto.php";
    //string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/penja_foto.php";
    //public string nomFotoPost;
    
    string nameUsuPost = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
    string nomGrup =  System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");


    //public GameObject textnom;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void penjafotoButton(){
        CreateUser(takeSavePhoto.nomPedra.text,nameUsuPost);
        Debug.Log("OK");
    }

    // Update is called once per frame
    
    //void Update()
    //{
        
        
        //if(Input.GetKeyDown(KeyCode.Space)){
            //CreateUser(takeSavePhoto.nomPedra.text,nameUsuPost);
           //Debug.Log("OK");
       // }
   // }
    public void CreateUser (string nomPedra, string nomUsu){
        string ruta = "C:/FotosGeo/" + nomPedra + "_" + nomUsu + "_" + nomGrup + ".png";
        byte[] foto = System.IO.File.ReadAllBytes(ruta);
        string logName = nomPedra + "_" + nomUsu + "_" + nomGrup + ".png";
        //Debug.Log(ruta);

        WWWForm form = new WWWForm();
        form.AddField("nameFotoPost",nomPedra);
        form.AddField("nameUsuPost",nomUsu);
        form.AddField("latitudPost",geoMapFoto.latitudText.text);
        form.AddField("longitudPost",geoMapFoto.longitudText.text);
        form.AddBinaryData("rutaPost", foto, logName);
        //form.AddField("rutaPost",ruta);
        //tinc que enviar la rutaPost

        //form.AddField("latitudPost",GeoMap.);
        WWW www = new WWW (createUserUrl,form);
    }
 
}