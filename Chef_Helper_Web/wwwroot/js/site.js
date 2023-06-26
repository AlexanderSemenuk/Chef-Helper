// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var adding = document.getElementById("adding");
adding.addEventListener("click", getDataing);
function getDataing() {
    var ingredientName = document.getElementById("ingredientNameInput").value;
    var ingredientQuantity = document.getElementById("ingredientQuantityInput").value;

    var data = {
        ingredientName: ingredientName,
        quantity: ingredientQuantity
    };

    fetch('api/warehouse', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Failed to add warehouse');
            }
        })
        .then(result => {
            // Обработка успешного ответа от сервера
            console.log(result);
        })
        .catch(error => {
            // Обработка ошибок
            console.error(error);
        });
}