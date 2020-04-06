using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ValidarFoto : MonoBehaviour
{

    string createUserUrl = "http://localhost/flors/alta_profe.php";


    public RawImage imageShot;

    Texture2D texture2D;

    public Text nomPedra;

    public Text nomUsu;

   // your filename

    
    
   // Image pictureBox1 = Image.FromFile("ieiva_pm_proba.jpg"); 
   

    public string[] items;
    // Start is called before the first frame update
    void Start()
    {
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        //CreateUser(grup);
        //pictureBox1 = System.Drawing.Image.FromFile(path);
        //texture2D = LoadPNG(path);
        //imageShot.texture = texture2D;
        //imageShot.texture = texture2D as Texture;

    }

    // Update is called once per frame
    /* public void CreateUser (string grup){
        WWWForm form = new WWWForm();
        form.AddField("grupPostAlta",grup);
        WWW www = new WWW (createUserUrl,form);

    }
    */
      
    	IEnumerator IECert(){
        int i = 0;
		WWW itemsData = new WWW("http://localhost/flors/validarfotos.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
        string nom = GetDataValue(items[i], "NOM:");
        string grup = GetDataValue(items[i], "ID_GRUP:");
        string usu = GetDataValue(items[i], "ID_USU:");
        //print(GetDataValue(items[i], "ID_USU:"));
         
        i++;
        StartCoroutine(IEAgafarnomusu(nom));
        enviarDADESCert(nom,grup,usu);

        
	}

    /*public string agafarnomusu(string id_usuari){
        WWW itemsData = new WWW("http://localhost/flors/validarfotos.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
    }
    */
    public void probaecho(){
        //StartCoroutine(IEAgafarnomusu());
    }
    IEnumerator IEAgafarnomusu(string nomroca){
        WWW itemsData = new WWW("http://localhost/flors/retornar_nomusu.php");
		yield return itemsData;
		string itemsDataString = itemsData.text.Trim();
		Debug.Log(itemsDataString);
        mostrarinfo(nomroca, itemsDataString);

    }

    public void enviarDADESCert(string nom, string grup, string usu){
         WWWForm form = new WWWForm();
        form.AddField("nomPOST",nom);
        form.AddField("id_grupPOST",grup);
        form.AddField("id_usuPOST",usu);
        form.AddField("correcte",cert());
        form.AddField("validada",1);
        WWW www = new WWW ("http://localhost/flors/correcte_validar.php",form);
    }

    public void mostrarinfo(string nom, string nom_usu){
        nomPedra.text = nom;
        nomUsu.text = nom_usu;
        mostrarFoto(nom,nom_usu);
    }

   
  public void mostrarFoto(string nom, string nom_usu){
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        string path = "C:/FotosGeo/" + nom + "_" + nom_usu + "_" + grup +".png";
        texture2D = LoadPNG(path);
        imageShot.texture = texture2D;
    }

    IEnumerator IEFals(){
        int i = 0;
		WWW itemsData = new WWW("http://localhost/flors/validarfotos.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
        string nom = GetDataValue(items[i], "NOM:");
        string grup = GetDataValue(items[i], "ID_GRUP:");
        string usu = GetDataValue(items[i], "ID_USU:");
        //print(GetDataValue(items[i], "ID_USU:"));
        i++;

        enviarDADESFals(nom,grup,usu);

        
	}

    public void enviarDADESFals(string nom, string grup, string usu){
         WWWForm form = new WWWForm();
        form.AddField("nomPOST",nom);
        form.AddField("id_grupPOST",grup);
        form.AddField("id_usuPOST",usu);
        form.AddField("correcte",fals());
        form.AddField("validada",1);
        WWW www = new WWW ("http://localhost/flors/correcte_validar.php",form);
    }
    

    /*public void EnviarDades(){
        StartCoroutine("enviarDADES");
    }
    */

	public string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}
    public void CertONCLICK(){
        StartCoroutine(IECert());
    }
    public void FalsONCLICK(){
        StartCoroutine(IEFals());
    }

    public void fotoCorrecte(){
        int correcte = 2;
        int validada = 1;
        WWWForm form = new WWWForm();
        form.AddField("validada",validada);
        form.AddField("correcte",correcte);
        WWW www = new WWW ("http://localhost/flors/correcte_validar.php",form);
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
         tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
     }
     return tex;
 }


 

}
