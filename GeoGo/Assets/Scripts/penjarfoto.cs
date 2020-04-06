using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penjarfoto : MonoBehaviour
{
    public GeoMapFoto geoMapFoto;
    public TakeSavePhoto takeSavePhoto;
    string createUserUrl = "http://localhost/flors/penja_foto.php";
    //string createUserUrl = "http://ec2-18-210-22-233.compute-1.amazonaws.com/~geogo/penja_foto.php";
    //public string nomFotoPost;
    
    string nameUsuPost = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");

    //public GameObject textnom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKeyDown(KeyCode.Space)){
            CreateUser(takeSavePhoto.nomPedra.text,nameUsuPost);
            Debug.Log("OK");
        }
    }
    public void CreateUser (string username, string password){
        WWWForm form = new WWWForm();
        form.AddField("nameFotoPost",username);
        form.AddField("nameUsuPost",password);
        form.AddField("latitudPost",geoMapFoto.latitudText.text);
        form.AddField("longitudPost",geoMapFoto.longitudText.text);

        //form.AddField("latitudPost",GeoMap.);
        WWW www = new WWW (createUserUrl,form);
    }

}