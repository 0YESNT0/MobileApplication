using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public string userName;
    public string password;
    public string firstName;
    public string lastName;
    public string email;
}

[System.Serializable]
public class UserList
{
    public List<User> users =  new List<User>();
}
