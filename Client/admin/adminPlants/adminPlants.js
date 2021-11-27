const obj = JSON.parse(sessionStorage.getItem('user'));
console.log(obj);

function handleHello(){
    var helloHtml = document.getElementById('hello');
    var html = `<li id="hello" class="nav-item accountPageButton"><a class="nav-link active" aria-current="page" href="../adminProfile/adminProfile.html">Hello ${obj.firstName}</a></li>`;
    helloHtml.innerHTML = html;
    loadPlants();
}

const GetPlant = async (id) => {
    const plantURL = `https://localhost:5001/api/plantinformation/${id}`;
    const response = await fetch(plantURL);
    const data = await response.json();
    displayModal(data);
    return data;
}

function addPlant(){
    const plantApiUrl = "https://localhost:5001/api/plantinformation";
    const namePlant = document.getElementById(`pname`).value;
    const plantLocation = document.getElementById(`plocation`).value;
    const waterNeeds = document.getElementById(`pwater`).value;
    const sunNeed = document.getElementById(`psun`).value;
    const plantInfo = document.getElementById(`pinfo`).value;
    const plantFact = document.getElementById(`pfact`).value;
    const plantPrice = document.getElementById(`pprice`).value;
    

    fetch(plantApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'

        },
        body: JSON.stringify({
            plantName: namePlant,
            location: plantLocation,
            numTimesWater: waterNeeds,
            sunNeeds: sunNeed,
            information: plantInfo,
            funFact: plantFact,
            price: plantPrice
        })
    })
    .then((response)=>{
        console.log(response);
        loadPlants();
    })
    var addMenu = document.getElementById("addButton");
    var html = `<button id = "adminAdd" class="btn btn-outline-dark" type="submit" onclick="displayAddMenu()">Add</button>`;
    addMenu.innerHTML = html;

}

function displayAddMenu(){
    var addMenu = document.getElementById("addButton");
    var html = `<div><div>`;
    html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">Add Plant</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
    html += `</div><div class="modal-body"><div>Plant Name: <input type="edit" value="Enter Name" id="pname"></div><div>Location: <input type="edit" value="Enter Location" id="plocation"></div><div>Water Needs: <input type="edit" value="Enter Water Needs" id="pwater"></div><div>Sun Needs: <input type="edit" value="Enter Sun Needs" id="psun"></div><div id="plantinfo">Plant Information: <input type="edit" value="Enter Plant Information" id="pinfo"></div><div>Fun Fact: <input type="edit" value="Enter Fun Fact" id="pfact"></div>`;
    html += ` <div>Price: <input type="edit" value="Enter Price" id="pprice"></div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-secondary" onclick="addPlant()">Add Plant</button>`;
    html += `</div></div></div>`;
    addMenu.innerHTML = html;
}

// var addMenu = document.getElementById("exampleModal");
// var html = `<div class="modal-dialog"><div class="modal-content">`;
// html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">Add Plant</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
// html += `</div><div class="modal-body"><div>Plant Name: <input type="edit" value="Enter Name" id="pname"></div><div>Location: <input type="edit" value="Enter Location" id="plocation"></div><div>Water Needs: <input type="edit" value="Enter Water Needs" id="pwater"></div><div>Sun Needs: <input type="edit" value="Enter Sun Needs" id="psun"></div><div id="plantinfo">Plant Information: <input type="edit" value="Enter Plant Information" id="pinfo"></div><div>Fun Fact: <input type="edit" value="Enter Fun Fact" id="pfact"></div>`;
// html += ` <div>Price: <input type="edit" value="Enter Price" id="pprice"></div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-secondary" onclick="addPlant()">Add Plant</button>`;
// html += `</div></div></div>`;


   
    


function displayModal(data){
    console.log(data);
    var garden = document.getElementById("exampleModal");
    var html = `<div class="modal-dialog"><div class="modal-content">`;
    html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel${data[0].plantName}">${data[0].plantName}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
    html += `</div><div class="modal-body"><img class="modalImg" src="./assets/plant-${data[0].plantID}.jpeg" alt="Picture" width="300" height="200"/><div>Location: <input type="edit" value="${data[0].location}" id="editLocation${data[0].plantID}"></div><div>Water Needs: <input type="edit" value="${data[0].numTimesWater} id="editWater${data[0].plantID}""></div><div>Sun Needs: <input type="edit" value="${data[0].sunNeeds}" id="editSun${data[0].plantID}"></div><div id="plantinfo">Plant Information: <input type="edit" value="${data[0].information}"id="editInfo${data[0].plantID}"></div><div>Fun Fact: <input type="edit" value="${data[0].funFact}" id="editFact${data[0].plantID}"></div>`;
    html += `<div>Price: <input type="edit" value="${data[0].price}" id="editPrice${data[0].plantID}"></div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-secondary" onclick="confirmation(${data[0].plantID})">Delete</button><button type="button" class="btn btn-primary" onclick="putPlant(${data[0].plantID})">Save Changes</button>`;
    html += `</div></div></div>`;
    garden.innerHTML = html;
}

function putPlant(id){
    const plantApiUrl = `https://localhost:5001/api/plantinformation/${id}`;
    const namePlant = document.getElementById(`exampleModalLabel${id}`).value;
    const plantLocation = document.getElementById(`editLocation${id}`).value;
    const waterNeeds = document.getElementById(`editWater${id}`).value;editWater;
    const sunNeed = document.getElementById(`editSun${id}`).value;editSun;
    const plantInfo = document.getElementById(`editInfo${id}`).value;editInfo;
    const plantFact = document.getElementById(`editFact${id}`).value;editFact;
    const plantPrice = document.getElementById(`editPrice${id}`).value;editPrice;
    fetch(plantApiUrl,{
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            plantID: id,
            plantName: namePlant,
            location: plantLocation,
            numTimesWater: waterNeeds,
            sunNeeds: sunNeed,
            information: plantInfo,
            funFact: plantFact,
            price: plantPrice

        })
    }).then((response)=>{
        console.log(response)
        loadPlants();
    })    
}

function confirmation(id){//STILL WORKING ON THIS
    var garden = document.getElementById("exampleModal");
    var html = `<div id="delete_message">`;
    html += `<h2>Are You Sure You Want To Delete This</h2>`;
    html += `<input type="button" onclick="removeElement(${id})" value="Delete" id="delete" >`;
    html += `<input type="button" value="Cancel" id="cancel" data-bs-dismiss="modal"></div>`;
    garden.innerHTML += html;
}

    
    
    
  

function removeElement(checkId){
    const plantUrl = `https://localhost:5001/api/plantinformation/${checkId}`;
    fetch(plantUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    })
    .then((response)=>{
        console.log(response);
        loadPlants();
    })
}

function loadPlants(){
    const allPlantsApiUrl = "https://localhost:5001/api/plantinformation";

    fetch(allPlantsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = `<div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">`;
        json.forEach((plantinformation) => {
            console.log(json);
            html += `<button type="button" class="modalButton" data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="GetPlant(${plantinformation.plantID})">`;
            html += `<div class="col mb-5"> <div class="card h-100">  <img class="card-img-top" src="./assets/plant-${plantinformation.plantID}.jpeg" alt="${plantinformation.plantName}" height="200px"/>`;
            html += `<div class="card-body p-4"> <div class="text-center"> <h5 class="fw-bold">${plantinformation.plantName}</h5>$${plantinformation.price}</div></div>`
            html += `<div class="card-footer p-4 pt-0 border-top-0 bg-transparent"> <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="#">View Plant Info</a></div></div></div></div></button>`
        });
        html += "</div>";
        document.getElementById("plantList").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
}



    
            
        
    

