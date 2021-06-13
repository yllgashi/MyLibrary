// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

authorizedHttpReq = async function (url, method) {
    var token = localStorage.getItem('_token');
    if (!token) {
        window.location.href = window.location.origin + '/login'
    }

    var response = await fetch(window.location.origin + url, {
        method: method || 'GET',
        headers: {
            'Authorization': 'Bearer ' + token
        }
    });

    // if user is not login, redirect to /login
    if (response.status === 401 || response.status === 403) {
        window.location.href = window.location.origin + '/login'
    }

    return await response.json();
    
}