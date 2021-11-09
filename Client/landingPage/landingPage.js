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
    return data;
}

function handleOnLoad(){

}

async function loginOnClick(json) {
    await GetCustomers();
    var email = document.getElementById("email");
    var password = document.getElementById("pass");

    console.log(data)
    if (email=data.email)
    {
        if (password=data.password)
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