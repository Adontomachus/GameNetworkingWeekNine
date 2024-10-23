using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Converters;
using UnityEditor;
using UnityEngine.TextCore.Text;


public class LogInScript : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TMP_InputField confirmPassword;
    public bool loggedIn = false;
    public GameObject loginScreen, mainUI;
    
    //public TMP_InputField loginusername;
    //public TMP_InputField loginpassword;
    //public TMP_InputField loginconfirmPassword;
    public GameObject invalidPassword;
    private Dictionary<string, string> credentials = new Dictionary<string, string>();
    // Start is called before the first frame update

    public void PlayerRegister()
    {
        var user = new UserCredentials()
        {
            Username = username.text,
            Password = password.text,
            ConfirmPassword = confirmPassword.text
        };
        if (password.text != confirmPassword.text)
        {
            invalidPassword.SetActive(true);
            Debug.Log("Invalid username or password.");     
        }
        else if (credentials.ContainsKey(user.Username))
        {
            Debug.Log("Username already exists.");
        }
        else if (password.text == confirmPassword.text)
        {
            credentials.Add(user.Username, user.Password);
            Debug.Log("Successfully Registered!");
            Debug.Log(JsonConvert.SerializeObject(user));      
        }

    }
    public void PlayerLogin()
    {
        string loginUser = username.text;
        string loginPass = password.text;
        if (credentials.TryGetValue(loginUser, out string storedPassword))
        {
            if (storedPassword == loginPass)
            {
                loginScreen.SetActive(false);
                loggedIn = true;
                Debug.Log("Login successful!");
            }
            else
            {
                Debug.Log("Invalid password.");
            }
        }
        else
        {
            Debug.Log("Username does not exist.");
        }
    }

    private void Update()
    {
        if (!loggedIn)
        {
            mainUI.SetActive(false);
        }
        if (loggedIn)
        {
            mainUI.SetActive(true);
        }
    }
}

    
    
    /*public void PlayerLogIn()
    {
        var user = new UserCredentials()
        {
            Username = loginusername.text,
            Password = loginpassword.text,
            ConfirmPassword = loginconfirmPassword.text
        };
        // Dictionary.TryGetValue(username.text, password.text);
        Debug.Log(JsonConvert.SerializeObject(user));    
    }*/

    
    // Update is called once per frame
    public struct UserCredentials
    {
        public string Username;
        public string Password;
        public string ConfirmPassword;
    }
