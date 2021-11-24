const obj = JSON.parse(sessionStorage.getItem('user'));
console.log(obj);

function handleHello(){
    var helloHtml = document.getElementById('hello');
    var html = `<li id="hello" class="nav-item accountPageButton"><a class="nav-link active" aria-current="page" href="../adminProfile/adminProfile.html">Hello ${obj.firstName}</a></li>`;
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
    console.log(data);
    var garden = document.getElementById("exampleModal");
    var html = `<div class="modal-dialog"><div class="modal-content">`;
    html += `<div class="modal-header"><h5 class="modal-title" id="exampleModalLabel">${data[0].plantName}</h5><button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>`;
    html += `</div><div class="modal-body"><img class="modalImg" src="./assets/plant-${data[0].plantID}.jpeg" alt="Picture" width="300" height="200"/><div>Location: ${data[0].location}</div><div>Water Needs: ${data[0].numTimesWater}</div><div>Sun Needs: ${data[0].sunNeeds}</div><div id="plantinfo">Plant Information: ${data[0].information}</div><div>Fun Fact: ${data[0].funFact}</div>`;
    html += `<div>Price: ${data[0].price}</div></div><div class="modal-footer"><button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button><button type="button" class="btn btn-primary" onclick="addToCart(${data[0].plantName}, ${data[0].plantID})">Add to Cart</button>`;
    html += `</div></div></div>`;
    garden.innerHTML = html;
}

var cart = {};
function addToCart(product){
	var productName = product.getAttribute("data-name");
	var price = product.getAttribute("data-price");

	cart[productName] = price;
	alert(productName + " successfully added to cart");


	console.log(cart);
	sessionStorage.setItem("myCart", JSON.stringify(cart));
}

function getCart(){
	var test = sessionStorage.getItem("myCart");
	console.log(JSON.parse(test));
}

function clearCart(){
	sessionStorage.removeItem("myCart");
}

function display(){
	var cart = JSON.parse(sessionStorage.getItem("myCart"));

	var content='';
	for (var key in cart) {
		var name = key; //B
		var price = cart[key];	 //15
	 	content += '<tr><td>'+name+'</td><td>'+price+'</td></tr>';
	}

	document.getElementById("cartTable").innerHTML = content;

}