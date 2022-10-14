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
        // Tarkistetaan ettei TitleID ole tyhj� eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lis�� oma TitleID,jonka l�yd�t PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "2C087"; 
        }

        //API-Kutsu (GET) s�hk�postikirjautumista varter
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    // T�m� metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }
    // T�m� metodi suoritetaan jos loggaus ep�onnistuu
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

    //Tallentaa Login-lomakkeelta tulleen s�hk�postiosoitteen

    public void GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }
    //login -painikkeen koodi eli t�ss� tehd��n API-kutsu Playfab pilveen ja selvitet��n onko k�ytt�j� olemassa
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
}