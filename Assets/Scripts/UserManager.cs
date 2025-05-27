using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    //we will save the users in a specific 
    //path in our client device
    private string filePath;
    public UserList userList = new UserList();

    public GameObject MainPage;
    public GameObject LoginPage;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath,
            "users.json");
        Debug.Log("Awake!");
        userList = new UserList();
        LoadUsers();
    }

    public void Register(string username, string password,
        string password_confirmation, string first_name,
        string last_name, string email)
    {
       
        if(userList.users.Exists(u => u.userName == username))
        {
            Debug.LogError("User Already Exist!");
            return;
        }

        if(userList.users.Exists(u => u.email == email))
        {
            Debug.LogError("Email Already Exist!");
        }

        if(password != password_confirmation)
        {
            Debug.LogError("Password mismatch!");
            return;
        }

        userList.users.Add(new User
        {
            userName = username,
            password = password,
            firstName = first_name,
            lastName = last_name,
            email = email
        });
        SaveUsers();
        Debug.Log("User Registered!");
    }

    public void LogIn(string email, string password){
        if(userList.users.Exists(u => u.email == email) == false)
        {
            
            Debug.LogError("Email Does not Exist!");
            return;
        }

        User userinfo = userList.users.Find(u => u.email == email);
        if(password == userinfo.password){
            Debug.Log("Log in Successful!");
            MainPage.SetActive(true);
            LoginPage.SetActive(false);

        }
        else{
            Debug.Log("Incorrect Password");
        }
    }

    void SaveUsers()
    {
        string json = JsonUtility.ToJson(userList);
        Debug.Log(json);
        File.WriteAllText(filePath, json);
    }

    void LoadUsers()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var loadedUsers = JsonUtility.FromJson<UserList>(json);
                if (loadedUsers != null)
                {
                    userList = loadedUsers;
                    foreach(User a in userList.users)
                    {
                        Debug.Log(a.userName);
                    }
                }
                else
                    Debug.LogWarning("JSON load failed, resetting user list.");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading JSON: " + e.Message);
            }
        }
        else
        {
            userList = new UserList();
        }
    }
}
