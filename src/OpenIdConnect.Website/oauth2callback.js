function initialize() {
    $("#getUserDetails").click(function () {
        getUserDetails('testAccessToken');
    });

    // NOTE (Cameron): The code is passed instead of the JWT because it's part of an HTTP GET, not POST.
    var code = getQueryStringComponent("code");

    getToken(code);
};

function getToken(code) {

    // NOTE (Cameron): So we now need to get the token using a POST.
    $.ajax({
        url: 'http://localhost/api/authenticate',
        type: 'POST',
        beforeSend: function (xhr) { 
            xhr.setRequestHeader ('Authorization', 'Basic abcdef123456' /* <= client credentials go here */); 
        },
        crossDomain: true,
        data: 'grant_type=authorization_code&code=' + code + '&redirect_uri=http%3A%2F%2Flocalhost:49856%2Foauth2callback.html',
        dataType: "json",
        accepts: { json: "application/json" },
        contentType: "application/x-www-form-urlencoded",
        success: function (data, textStatus, jqXHR) {
            $('body p').html('access_token: ' + data.access_token + '<br />id_token: ' + data.id_token);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('body p').html('Error!');
        }
    });

};

function getUserDetails(accessToken) {

    // NOTE (Cameron): So we now need to get the token using a POST.
    $.ajax({
        url: 'http://localhost/resource/userdetails',
        type: 'GET',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + accessToken);
        },
        crossDomain: true,
        dataType: "json",
        accepts: { json: "application/json" },
        success: function (data, textStatus, jqXHR) {
            $('body p').html('username: ' + data.username + '<br />emailAddress: ' + data.emailAddress);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $('body p').html('Error!');
        }
    });

};

// LINK (Cameron): https://bitbucket.org/cameronfletcher/brownbag/src/6ccce6d67233/Website/scripts/seminars.js?at=default
var getQueryStringComponent = function (name) {
    var urlParams = {};
    var match,
        pl = /\+/g,  // regex for replacing addition symbol with a space
        search = /([^&=]+)=?([^&]*)/g,
        decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
        query = window.location.search.substring(1);

    while (match = search.exec(query))
        urlParams[decode(match[1])] = decode(match[2]);

    return urlParams[name];
};