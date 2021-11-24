/*!
* Start Bootstrap - Shop Homepage v5.0.4 (https://startbootstrap.com/template/shop-homepage)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-shop-homepage/blob/master/LICENSE)
*/
// This file is intentionally blank
// Use this file to add JavaScript to your project
const GetGarden = async (id) => {
  const gardenURL = `https://localhost:5001/api/garden/${id}`;
  const response = await fetch(gardenURL);
  const data = await response.json();
  displayModal(data);
  return data;
}

function displayModal(data){
  var garden = document.getElementById("garden");
  var html = '<div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" tabindex="-1">'
  html += `<div class="modal-dialog"><div class="modal-content"><div class="modal-header"><h5 class="modal-title">${data[0].gardenType}</h5>`
  html += `<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick='backToPic()'></button></div><div class="modal-body"><p>${data[0].information}</p>`
  html += `<img src="./assets/outdoorgarden.jpg" alt="Outdoor Garden" width="300" height="200"/></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick='backToPic()'>Close</button>`
  html += '</div></div></div></div>'
  garden.innerHTML = html
}

function backToPic(){
  var garden = document.getElementById("garden");
  var html = '<div class="garden" id="garden"><img id="myImg" src="./assets/outdoorgarden.jpg" alt="Outdoor Garden" width="300" height="200" onclick="GetGarden(2)">'
  html += '<h2 style="text-align: center; padding: 10px; font-family: Impact, Haettenschweiler, `Arial Narrow Bold`, sans-serif;">Outdoor Garden</h2></div>'
  garden.innerHTML = html;
}

var myModal = new bootstrap.Modal(document.getElementById('myModal'))

// Get the modal
//var modal = document.getElementById('myModal');

// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById('myImg');
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
var information = document.getElementById("info");
img.onclick = function(){
  myModal.style.display = "block";
  modalImg.src = this.src;
  captionText.innerHTML = this.alt;
  //information.innerHTML = data;
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function() { 
  myModal.style.display = "none";
}