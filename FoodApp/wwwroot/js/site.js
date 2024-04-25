// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let apiURL = "https://forkify-api.herokuapp.com/api/v2/recipes"
let apiKey = "03cf286a - 4208 - 4186 - 82df - 97c23023ae21"

async function GetRecipes(RecipeName,id,isAllShow) {
    let resp = await fetch(`${apiURL}?search=${RecipeName}&Key=${apiKey}`);
    let result = await resp.json();
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(1, 7);
    showRecipes(Recipes, id);
}
function showRecipes(recipes, id) {
    $.ajax({
        contentType: "application/json; charset=utf-8",
        dataType:'html',
        type:'POST',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResults) {
            $('#' + id).html(htmlResults);
        }
    })
}


async function getOrderRecipe(id, showId) {
    let resp = await fetch(`${apiURL}/${id}?Key=${apiKey}`);
    let result = await resp.json();
    let recipe = result.data.recipe;
    showOrderRecipeDetails(recipe, showId);

}

function showOrderRecipeDetails(orderRecipeDetails, showId) {
    $.ajax({
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/ShowOrder',
        data: orderRecipeDetails,
        success: function (htmlResults) {
            $('#' + showId).html(htmlResults);
        }
    })
}

function quantity(option) {
    let qty = $('#qty').val();
    let price = parseInt($('#price').val());
    let totalAmount = 0;
    if (option === 'inc') {
        qty = parseInt(qty) + 1;
    } else {
        qty = qty == 1 ? qty : qty - 1;
    }
    totalAmount = price * qty;
    $('#qty').val(qty)
    $('#totalAmount').val(totalAmount)
}