function initialize() {
    $("#logon").click(function () {
        window.location = "https://accounts.google.com/o/oauth2/auth?scope=openid&state=whatever&response_type=code&client_id=519195177062.apps.googleusercontent.com&redirect_uri=http%3A%2F%2Flocalhost:49856%2Foauth2callback.html&access_type=offline";
    });
};