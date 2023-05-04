using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class registration : MonoBehaviour
{
    public TMPro.TMP_InputField accountEmail;
    public TMPro.TMP_InputField accountPassword;
    //public Text info;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void Accountregister()
    {
        string email = accountEmail.text;
        string password = accountPassword.text;
        StartCoroutine(registerNewAccount(email, password));
    }

    
    IEnumerator registerNewAccount(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("NewAccountemail", email);
        form.AddField("NewAccountpassword", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/documents/", form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError) 
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response Text from the server = " + responseText);
                //info.text = "Response Text from the server = " + responseText;
            }
        }
    } 

}
