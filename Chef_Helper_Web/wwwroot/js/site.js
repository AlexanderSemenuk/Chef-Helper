// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
 const addButton = document.getElementById("addButton");

    addButton.addEventListener("click", () => {
      const name = prompt("Введите название:");
      const calories = prompt("Введите калории:");
      const products = prompt("Введите продукты:");
      const weight= prompt("Введите вес:");
    });
	const data = {
	name: name,
	calories: calories,
	products: products
	};
	fetch("api/Recipe", {
	method: "POST",
	headers: {
    "Content-Type": "application/json"
	},
	body: JSON.stringify(data)
	})
	.then(response => {
    if (response.ok) {
      console.log("Data successfully sent to ASP.NET backend.");
    } else {
      console.error("Error sending data to ASP.NET backend.");
    }
	})
	.catch(error => {
    console.error("Error sending data to ASP.NET backend:", error);
	});