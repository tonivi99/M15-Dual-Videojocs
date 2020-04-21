using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public GameObject fotobuttonUI;

    public void FerFoto(){
        SceneManager.LoadScene("FerFoto");
    }

    public void penjarfoto(){
         fotobuttonUI.SetActive(true);
    }
    public void tornaraFoto(){
         fotobuttonUI.SetActive(false);
    }
    public void tornarMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void AltaUsuari(){
        SceneManager.LoadScene("AltaUsuari");
    }
    public void BorrarUsuari(){
        SceneManager.LoadScene("BaixaUsuari");
    }
    public void TornarMenuProfe(){
        SceneManager.LoadScene("Profe");
    }
    public void ModificarUsuari(){
        SceneManager.LoadScene("ModificarUsuari");
    }
    public void validarFoto(){
        SceneManager.LoadScene("ValidarFotos");
    }
    public void NotificacioProfe(){
        SceneManager.LoadScene("Notificacions Profe");
    }
}
