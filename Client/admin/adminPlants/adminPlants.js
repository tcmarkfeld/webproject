const GetPlant = async (id) => {
    const gardenURL = `https://localhost:5001/api/plantinformation/${id}`;
    const response = await fetch(gardenURL);
    const data = await response.json();
    displayModal(data);
    return data;
}

function displayModal(data){
    console.log(data);
    var garden = document.getElementById("exampleModal");
    var html = `<div class="modal-dialog"><div class="modal-content">`;
    html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">${data[0].plantName}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
    html += `</div><div class="modal-body"><div>Location: ${data[0].location}</div><img class="modalImg" src="./assets/plant-${data[0].plantID}.jpeg" alt="Picture" width="300" height="200"/><div>Water Needs: ${data[0].numTimesWater}</div><div>Sun Needs: ${data[0].sunNeeds}</div><div id="plantinfo">Plant Information: ${data[0].information}</div><div>Fun Fact: ${data[0].funFact}</div>`;
    html += `<div>Price: ${data[0].price}</div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary">Save changes</button>`;
    html += `</div></div></div>`;
    garden.innerHTML = html;
  }