const obj = JSON.parse(sessionStorage.getItem('user'));

function handleHello(){
  var helloHtml = document.getElementById('hello');
  var html = `<li id="hello" class="nav-item accountPageButton"><a class="nav-link active" aria-current="page" href="../custProfile/custProfile.html">Hello ${obj.firstName}</a></li>`;
  helloHtml.innerHTML = html;
}

const GetGarden = async (id) => {
  const gardenURL = `https://localhost:5001/api/garden/${id}`;
  const response = await fetch(gardenURL);
  const data = await response.json();
  displayModal(data);
  return data;
}

function displayModal(data){
  console.log(data);
  var garden = document.getElementById("exampleModal");
  var html = `<div class="modal-dialog"><div class="modal-content">`;
  html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">${data[0].gardenType}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
  html += `</div><div class="modal-body"><img class="modalImg" src="./assets/garden-${data[0].gardenID}.jpg" alt="House Plants" width="300" height="200"/><div id="gardeninfo">${data[0].information}</div>`;
  html += `</div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary">Save changes</button>`;
  html += `</div></div></div>`;
  garden.innerHTML = html;
}

function getSlider(value, oldValue){
  console.log(oldValue);
  var garden = document.getElementById(`modalButton-${oldValue}`);
  garden.classList.remove('selected');
  displayGarden(value);
}

function displayGarden(value){
  var garden = document.getElementById(`modalButton-${value}`);
  garden.classList.add('selected');
}

// function deleteClass(value){
//   console.log(value);
//   var garden = document.getElementById(`modalButton-${value}`);
//   garden.classList.remove('selected');
// }

// range slider
// var output = document.getElementById("demo");
// output.innerHTML = slider.value;

// slider.oninput = function() {
//   console.log()
//   output.innerHTML = this.value;
// }







// const displayDataInCaption = (data) =>{
//   var info = document.getElementById("info");
//   var html = `${data.information}`
//   info.innerHTML = html;
// }

// // Get the <span> element that closes the modal
// var span = document.getElementsByClassName("close")[0];

// When the user clicks on <span> (x), close the modal
// span.onclick = function() { 
//   modal.style.display = "none";
// }

// var modal = new bootstrap.Modal(document.getElementById('myModal'), options)

// //var modal = document.getElementById('myModal');

// // Get the image and insert it inside the modal - use its "alt" text as a caption
// var img = document.getElementById('myImg'); // House plant garden modal
// var modalImg = document.getElementById("img01");
// var captionText = document.getElementById("body");
// img.onclick = function(){
//   modal.style.display = "block";
//   modalImg.src = this.src;
//   captionText.innerHTML = this.alt;
// }