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