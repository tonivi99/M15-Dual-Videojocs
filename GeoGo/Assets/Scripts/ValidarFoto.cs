using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class ValidarFoto : MonoBehaviour
{
    public RawImage imageShot;

    Texture2D texture2D;

    public Text nomPedra;

    public Text nomUsu;

    public string nom;
    public string grup;
    public string usu;

    public string[] items;
    // Start is called before the first frame update
    void Start()
    {
        //string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        StartCoroutine(IECert());

    }
      
    	IEnumerator IECert(){
        string grupLlegir = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        int i = 0;
        WWWForm form = new WWWForm();
        form.AddField("grupPostAlta", grupLlegir);
		WWW itemsData = new WWW("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/validarfotos.php",form);
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
        nom = GetDataValue(items[i], "NOM:");
        grup = GetDataValue(items[i], "ID_GRUP:");
        usu = GetDataValue(items[i], "ID_USU:");
        //print(GetDataValue(items[i], "ID_USU:"));
         
        i++;
        StartCoroutine(IEAgafarnomusu(nom, usu, grup));
        //enviarDADESCert(nom,grup,usu);

        
	}

    IEnumerator IEAgafarnomusu(string nomroca,string id_usu, string id_grup){
        int id_usuari = Int32.Parse(id_usu);
        WWWForm form = new WWWForm();
        form.AddField("id_usuPost", id_usuari);
        WWW itemsData = new WWW("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/retornar_nomusu.php",form);
		yield return itemsData;
		string itemsDataString = itemsData.text.Trim();
		Debug.Log(itemsDataString);
        //proba 2 lineas de abaix modificades
        descargarFotos(nomroca, id_usu, id_grup, itemsDataString);
       
    }

     public void descargarFotos(string nomF, string id_grup, string id_usu, string nomUsuari){
        string Nomgrup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        //string imageUrl = "https://geogo.s3.amazonaws.com/2/98/corn3_pep_kakita.png";
        string imageUrl = "https://geogo.s3.amazonaws.com/" + id_usu + "/" + id_grup + "/" + nomF + "_" + nomUsuari + "_" + Nomgrup + ".png";
        Debug.Log(imageUrl);
        //string localFilename = "C:/DescargasFotosGeo/corn2_pep_kakita.png";
        string localFilename = "C:/DescargasFotosGeo/" + nomF + "_" + nomUsuari + "_" + Nomgrup + ".png"; 
        
        using(WebClient client = new WebClient()) { 
            client.DownloadFile(imageUrl, localFilename); 
        }

         mostrarinfo(nomF, nomUsuari, Nomgrup);

    }

    public void enviarDADESCert(string nom, string grup, string usu){
         WWWForm form = new WWWForm();
        form.AddField("nomPOST",nom);
        form.AddField("id_grupPOST",grup);
        form.AddField("id_usuPOST",usu);
        form.AddField("correcte",cert());
        form.AddField("validada",1);
        WWW www = new WWW ("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/correcte_validar.php",form);
    }

    public void mostrarinfo(string nom, string nom_usu, string nomGrup){
        nomPedra.text = nom;
        nomUsu.text = nom_usu;
        mostrarFoto(nom,nom_usu, nomGrup);
    }

   
  public void mostrarFoto(string nomPedra, string nom_usu, string nomGrup){

        string path = "C:/DescargasFotosGeo/" + nomPedra + "_" + nom_usu + "_" + nomGrup + ".png"; 
        texture2D = LoadPNG(path);
        imageShot.texture = texture2D;
    }

    public void enviarDADESFals(string nom, string grup, string usu){
         WWWForm form = new WWWForm();
        form.AddField("nomPOST",nom);
        form.AddField("id_grupPOST",grup);
        form.AddField("id_usuPOST",usu);
        form.AddField("correcte",fals());
        form.AddField("validada",1);
        WWW www = new WWW ("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/correcte_validar.php",form);
    }
    

	public string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}
    public void CertONCLICK(){
        //StartCoroutine(IECert());
        enviarDADESCert(nom,grup,usu);
        StartCoroutine(IECert());
    }
    public void FalsONCLICK(){
        enviarDADESFals(nom,grup,usu);
        StartCoroutine(IECert());
    }

    public void fotoCorrecte(){
        int correcte = 2;
        int validada = 1;
        WWWForm form = new WWWForm();
        form.AddField("validada",validada);
        form.AddField("correcte",correcte);
        WWW www = new WWW ("http://ec2-18-210-22-233.compute-1.amazonaws.com/~planta/correcte_validar.php",form);
    }
    public void fotoIncorrecte(){
        int correcte = 1;
        int validada = 1;
        WWWForm form = new WWWForm();
        form.AddField("correcte",correcte);
        form.AddField("validada",validada);
        WWW www = new WWW ("http://localhost/flors/correcte_validar.php",form);
    }
    
    public int cert (){
        int correcte = 2;
        return correcte;
    }
    public int fals(){
        int correcte = 1;
        return correcte;
    }

     public static Texture2D LoadPNG(string filePath) {
 
     Texture2D tex = null;
     byte[] fileData;
 
     if (File.Exists(filePath))     {
         fileData = File.ReadAllBytes(filePath);
         tex = new Texture2D(2, 2);
         tex.LoadImage(fileData); 
     }
     return tex;
 }


 

}