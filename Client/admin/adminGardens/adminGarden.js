const GetGarden = async (id) => {
  const gardenURL = `https://localhost:5001/api/garden/${id}`;
  const response = await fetch(gardenURL);
  const data = await response.json();
  displayModal(data);
  return data;
}

// function loadModal(){
// $( "#exampleModal" ).load( "modal.html" );
// }

function displayModal(data){
  console.log(data);
  var garden = document.getElementById("exampleModal");
  var html = `<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"><div class="modal-dialog"><div class="modal-content">`;
  html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">${data[0].gardenType}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
  html += `</div><div class="modal-body"><img id="myImg" src="./assets/garden-${data[0].gardenID}.jpg" alt="House Plants" width="300" height="200"/><div id="gardeninfo">${data[0].information}</div>`;
  html += `</div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary">Save changes</button>`;
  html += `</div></div></div></div>`;
  garden.innerHTML = html;
}


var myModal = new bootstrap.Modal(document.getElementById('exampleModal'))

// // Get the modal
// var modal = document.getElementById('myModal');

// // Get the image and insert it inside the modal - use its "alt" text as a caption
// var img = document.getElementById('myImg');
// var modalImg = document.getElementById("img01");
// var captionText = document.getElementById("caption");
// var information = document.getElementById("info");
// img.onclick = function(){
//   myModal.style.display = "block";
//   modalImg.src = this.src;
//   captionText.innerHTML = this.alt;
//   //information.innerHTML = data;
// }

// // // Get the <span> element that closes the modal
// var span = document.getElementsByClassName("close")[0];

// // // When the user clicks on <span> (x), close the modal
// span.onclick = function() { 
//   myModal.style.display = "none";
// }