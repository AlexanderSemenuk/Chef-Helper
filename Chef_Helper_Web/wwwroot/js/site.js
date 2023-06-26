// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const addButton = document.getElementById("addButton");

addButton.addEventListener("click", () => {
    const name = prompt("Введите название:");
    const calories = prompt("Введите калории:");
    const products = prompt("Введите продукты:");
    const weight = prompt("Введите вес:");

    const recipe = {
        name: name,
        calories: calories,
        products: products,
        weight: weight
    };

    fetch("/api/Recipe", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(recipe)
    })
        .then(response => {
            if (response.ok) {
                // The recipe was successfully added to the database
                console.log("Recipe added successfully");
            } else {
                // There was an error adding the recipe
                console.error("Failed to add recipe");
            }
        })
        .catch(error => {
            console.error("An error occurred:", error);
        });
});

const addButton = document.getElementById("addButton1");

addButton.addEventListener("click", () => {
    const name1 = prompt("Введите ингридиента:");
    const cout = prompt("Введите количество:");

    const recipe = {
        name1: name1,
        cout: cout
    };

    fetch("api/Warehouse", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(recipe)
    })
        .then(response => {
            if (response.ok) {
                // The recipe was successfully added to the database
                console.log("Recipe added successfully");
            } else {
                // There was an error adding the recipe
                console.error("Failed to add recipe");
            }
        })
        .catch(error => {
            console.error("An error occurred:", error);
        });
});