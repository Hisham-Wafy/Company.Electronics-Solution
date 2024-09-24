// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

import { post } from "jquery";

// Write your JavaScript code.





let name = document.getElementById("Id");

name.addEventListener("Keyup", () => {

    let xhr = new XMLHttpRequest();

    let url = 'http://localhost:44370/Employees/Index?InputSearch=${name.value}';
    xhr.open(post, url, true);

    xhr.onreadystatechange = function ()
    {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
        }
    }
    xhr.send();

});


