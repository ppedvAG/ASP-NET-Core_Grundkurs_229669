//Button in View -> API ansprechen
document.addEventListener('DOMContentLoaded', function () {
	const button = document.getElementById('getCustomer');
	button.addEventListener('click', buttonClick);
});

//function buttonClick() {
//	fetch('http://localhost:5000/api/CustomerAPI/Customer/ALFKI').
//		then(response => response.json()).
//		then(function (customer) {
//			let cust = customer;
//			alert("CustomerID: " + cust.CustomerId);
//		})
//}

function buttonClick() {
	alert("Test");
}