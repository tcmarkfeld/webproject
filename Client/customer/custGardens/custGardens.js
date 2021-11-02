/*!
* Start Bootstrap - Shop Homepage v5.0.4 (https://startbootstrap.com/template/shop-homepage)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-shop-homepage/blob/master/LICENSE)
*/
// This file is intentionally blank
// Use this file to add JavaScript to your project

// Get the modal
var modal = document.getElementById('myModal');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById('myImg');
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
img.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
  captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function() { 
  modal.style.display = "none";
}

//Upload caption to the garden
function handleOnLoad(id){
  const gardenURL = `https://localhost:5001/api/garden/${id}`;
  fetch(gardenURL).then(function(response){
      return response.json();
  }).then(function(json){
      console.log(json);
      displayTable(json)
  }).catch(function(error){
      console.log(error);
  });
}

function displayTable(json){
  var caption = document.getElementById("caption");
  var html = "<table><tr><th>Information</th></tr>";
  json.forEach(garden => {
      html+=`<tr><td>${garden.information}</td></tr>`;
  });
  html+="</table>";
  caption.innerHTML = html;
}