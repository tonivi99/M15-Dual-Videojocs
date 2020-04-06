using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
public class IniciProject : MonoBehaviour
{
    //    private string pathFileName = "/storage/emulated/0/DCIM/Camera/primeraObertuta.txt";
    //    private string savePath = "/storage/emulated/0/DCIM/Camera/";
    //    private string fileName = "primeraObertuta.txt";

    public InputField contrasenya;
    public GameObject professor;
    public GameObject alumne;
    private string pathFileName = "/";
    private string savePath = "/";
    private string fileNameOrigin = "/grup.txt";
    private string fileNameUsu = "C:/FotosGeo/arxiusdirectory/nomusuari.txt";
    private string fileNameProfe = "C:/FotosGeo/arxiusdirectory/nomprofessor.txt";



    string LoginURL = "http://localhost/flors/login.php";
    private bool ok_bbdd = false;
     private String dataPath = "C:/FotosGeo/arxiusdirectory";

    // Start is called before the first frame update
    void Start()
    {
        if (Directory.Exists (dataPath))
        {
            // ************************************************   Arranc Normal  ********************************************************
            if (System.IO.File.Exists(fileNameUsu))
            {
                //Usuari alumne
                // Llegir grup.txt
                // llegir usuari.txt
                StartCoroutine(LoginToDB());
                
            }
            else if(System.IO.File.Exists(fileNameProfe))
            {
                // Usuari Professor
                // llegir grup.txt
                StartCoroutine(LoginToDBProfe());
            }
        }
        else
        {
            // ************************************************  Primera arrancada ******************************************************
            // Entrar Contrasenya 
            if (contrasenya.text=="3*Tres=noU")  // Contrasenya Admin
            {
                // Crear grup // posar nom a la bbdd
                // Crear Usuari i Contrasenya d'usuari profe a la bbdd
                professor.SetActive(true);
                //System.IO.File.WriteAllText(fileNameOrigin, "codi_GRUP");
            }
            else
            {
                if (contrasenya.text == "a/enmulA") // Contrasenya Alumne 
                {
                    // Input nom de grup
                    // Input nom usuari / contrasenya
                    // Validar existència de l'usuari a la BBDD
                    ok_bbdd = true;
                    if (ok_bbdd)
                    {
                        System.IO.File.WriteAllText(fileNameOrigin, "codi_GRUP");
                        System.IO.File.WriteAllText(fileNameUsu, "codi_Alumne");
                    }
                }

            }

        }
    }

    public void Entrar(){
         if (contrasenya.text=="3*Tres=noU"){
             professor.SetActive(true);
         } else if(contrasenya.text == "a/enmulA"){
             alumne.SetActive(true);

         }else{
             Debug.Log("codi incorrecte");
         }
    }

     IEnumerator LoginToDB(){
         Debug.Log("entra a la funcio");
        string username = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
        string passwordname = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/password.txt");
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost",username);
        form.AddField("passwordPost",passwordname);
        form.AddField("grupPost",grup);
        WWW www = new WWW(LoginURL,form);
        yield return www;
        Debug.Log(www.text);

        if (www.text.Contains("Tot OK !!!")){
            SceneManager.LoadScene("Menu");

        }
        if(www.text.Contains("Error: Usuari desconegut")){
           File.Delete("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
           File.Delete("C:/FotosGeo/arxiusdirectory/password.txt");
           File.Delete("C:/FotosGeo/arxiusdirectory/grup.txt");
           Directory.Delete(dataPath);
           SceneManager.LoadScene("PrimeraArrancada");
            
        }
        if(www.text.Contains("Error: Password incorrecte")){
          File.Delete("C:/FotosGeo/arxiusdirectory/nomusuari.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/password.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/grup.txt");
          Directory.Delete(dataPath);
          SceneManager.LoadScene("PrimeraArrancada");
        }

    }

    IEnumerator LoginToDBProfe(){
        string username = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/nomprofessor.txt");
        string passwordname = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/password.txt");
        string grup = System.IO.File.ReadAllText("C:/FotosGeo/arxiusdirectory/grup.txt");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost",username);
        form.AddField("passwordPost",passwordname);
        form.AddField("grupPost",grup);
        WWW www = new WWW(LoginURL,form);
        yield return www;
        Debug.Log(www.text);

        if (www.text.Contains("Tot OK !!!")){
            SceneManager.LoadScene("Profe");

        }
        if(www.text.Contains("Error: Usuari desconegut")){
           // Debug.Log("usuari desconegut");
          File.Delete("C:/FotosGeo/arxiusdirectory/nomprofessor.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/password.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/grup.txt");
          Directory.Delete(dataPath);
          SceneManager.LoadScene("PrimeraArrancada");

            
        }
        if(www.text.Contains("Error: Password incorrecte")){
          //  Debug.Log("password incorrecte");
          File.Delete("C:/FotosGeo/arxiusdirectory/nomprofessor.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/password.txt");
          File.Delete("C:/FotosGeo/arxiusdirectory/grup.txt");
          Directory.Delete(dataPath);
          SceneManager.LoadScene("PrimeraArrancada");
        }

    }


    // ************************************************  Codic Temporal ******************************************************

    public void AlumnDirect(){
        SceneManager.LoadScene("Menu");
    }
    public void ProfeDirect(){
        SceneManager.LoadScene("Profe");
    }

}
