using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
public class PlayFabLogin : MonoBehaviour 
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;

    public void Start() 
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID,jonka löydät PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "2C087"; 
        }

        //API-Kutsu (GET) sähköpostikirjautumista varter
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    // Tämä metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }
    // Tämä metodi suoritetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    //Tallentaa Login-lomakkeelta tulleen salasanan

    public void GetUserPasswordLogin(string passwordIn)
    {
        userPasswordLogin = passwordIn;
    }

    //Tallentaa Login-lomakkeelta tulleen sähköpostiosoitteen

    public void GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }
    //login -painikkeen koodi eli tässä tehdään API-kutsu Playfab pilveen ja selvitetään onko käyttäjä olemassa
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
}