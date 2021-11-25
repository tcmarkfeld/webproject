const obj = JSON.parse(sessionStorage.getItem('user'));

function handleHello(){
    var helloHtml = document.getElementById('hello');
    var html = `<li id="hello" class="nav-item accountPageButton"><a class="nav-link active" aria-current="page" href="../custProfile/custProfile.html">Hello ${obj.firstName}</a></li>`;
    helloHtml.innerHTML = html;
}

const GetPlant = async (id) => {
    const plantURL = `https://localhost:5001/api/plantinformation/${id}`;
    const response = await fetch(plantURL);
    const data = await response.json();
    displayModal(data);
    return data;
}

function displayModal(data){
    var garden = document.getElementById("exampleModal");
    var html = `<div class="modal-dialog"><div class="modal-content">`;
    html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">${data[0].plantName}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
    html += `</div><div class="modal-body"><img class="modalImg" src="./assets/plant-${data[0].plantID}.jpeg" alt="Picture" width="300" height="200"/><div>Location: ${data[0].location}</div><div>Water Needs: ${data[0].numTimesWater}</div><div>Sun Needs: ${data[0].sunNeeds}</div><div id="plantinfo">Plant Information: ${data[0].information}</div><div>Fun Fact: ${data[0].funFact}</div>`;
    html += `<div>Price: ${data[0].price}</div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary" onclick="GetPlantCart(${data[0].plantID})">Add to Cart</button>`;
    html += `</div></div></div>`;
    garden.innerHTML = html;
}


const GetPlantCart = async (id) => {
    const plantURL = `https://localhost:5001/api/plantinformation/${id}`;
    const response = await fetch(plantURL);
    const data = await response.json();
    addToCart(data);
    return data;
}

var cart = {};
async function addToCart(data){
    var cartHtml = document.getElementById("cartNum");
	var productName = data[0].plantName;
	var price = data[0].price;

	cart[productName] = price;
	alert(productName + " has successfully been added to your cart");
    
	console.log(cart);
	sessionStorage.setItem("myCart", JSON.stringify(cart));
    cartHtml.innerHTML = sessionStorage.length;
    console.log(sessionStorage.length)
    console.log(sessionStorage.getItem('myCart'))
}

function getCart(){
    var cartHtml = document.getElementById("cartNum");
	var test = sessionStorage.getItem("myCart");
	console.log(JSON.parse(test));
    cartHtml.innerHTML = JSON.parse(sessionStorage.length);
}

function clearCart(){
	sessionStorage.removeItem("myCart");
}

function cartModal(){
	var cart = JSON.parse(sessionStorage.getItem("myCart"));
    console.log(cart);

    html = `<div class="modal-dialog"><div class="modal-content">`
    html += `<div class="modal-header"><h5 class="modal-title">Cart</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`
    html += `</div><div class="modal-body"><p>${cart.toString()}</p></div><div class="modal-footer">`
    html += `<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary">Checkout</button></div></div></div>`
          
	// var content='';
	// for (var key in cart) {
	// 	var name = key; //B
	// 	var price = cart[key];	 //15
	//  	content += '<tr><td>'+name+'</td><td>'+price+'</td></tr>';
	// }

	document.getElementById("cartModal").innerHTML = html;

}