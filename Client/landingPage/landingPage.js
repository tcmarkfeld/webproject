/*!
* Start Bootstrap - Shop Homepage v5.0.4 (https://startbootstrap.com/template/shop-homepage)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-shop-homepage/blob/master/LICENSE)
*/
// This file is intentionally blank
// Use this file to add JavaScript to your project

// sticky nav bar
// window.onscroll = function() {myFunction()};

// var stickyNav = document.getElementById("stickyNav");
// var sticky = stickyNav.offsetTop;

// function myFunction() {
//   if (window.pageYOffset >= sticky) {
//     stickyNav.classList.add("sticky")
//   } else {
//     stickyNav.classList.remove("sticky");
//   }
// }
const GetCustomers = async (email) => {
    const customerURL = `https://localhost:5001/api/customer/${email}`;
    const response = await fetch(customerURL);
    const data = await response.json();
    console.log(data);
    loginOnClick(data)
    return data;
}

function handleOnLoad(email){
    const postURL = `https://localhost:5001/api/customer/${email}`;
    fetch(postURL).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        loginOnClick(json);
    }).catch(function(error){
        console.log(error);
    });
}

async function loginOnClick(json) {
    var emailval = document.getElementById("email").value;
    var pass = document.getElementById("pass").value;
    var obj = JSON.parse(json)
    console.log(emailval);
    console.log(pass);
    console.log(json);

    console.log(obj.email)
    if (emailval=obj.email)
    {
        if (pass=obj.password)
        {
            window.location.replace("C:\source\repos\webproject\Client\customer\custProfile\custProfile.html");
        }
    }
    else{
        console.log("error");
        var html = "<div>Incorrect email or password. Try again</div>";
        document.getElementById("pass").outerHTML = html
    }
}