using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmpasswordInput;
    public TMP_InputField firstnameInput;
    public TMP_InputField lastnameInput;
    public TMP_InputField emailInput;

    public TMP_InputField LogInemailInput;
    public TMP_InputField LogInpasswordInput;

    public UserManager userManager;

    public GameObject MainPage;
    

    public void RegisterButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string confirmpassword = confirmpasswordInput.text; 
        string firstname = firstnameInput.text;
        string lastname = lastnameInput.text;
        string email = emailInput.text;

        userManager.Register(username, password, confirmpassword,
            firstname, lastname, email);
    }

    public void LogInBTNClicked(){
        string password = LogInpasswordInput.text;
        string email = LogInemailInput.text;

        userManager.LogIn(email,password);
    }
}
