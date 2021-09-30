var selectedstore = document.getElementsByTagName('label')[0];
const listofproductsdiv = document.querySelector(`.listofproductsdiv`);
const submitdiv = document.querySelector(`.submitdiv`);
var button = false;


function OnSubmitForm() {
    if (document.getElementById('1').checked == true) {
        LoadProducts(1);
    }
    else if (document.getElementById('2').checked == true) {
        LoadProducts(2);
    }
    else if (document.getElementById('3').checked == true) {
        LoadProducts(3);
    }

    fetch(`../stores/GetAllStores`)
    .then(res => res.json())
    .then(res => {
        console.log(res)
    })
    return false;
}



function LoadProducts(id) {
    
    //get the first inner DIV which contains all the a elements
    var innerDiv = listofproductsdiv.getElementsByClassName('product');
    //This will hide all matching elements except the first one
    for (var i = 0; i < innerDiv.length; i++) {
        var a = innerDiv[i];
        a.style.display = 'none';
    }
    var innerDiv1 = listofproductsdiv.getElementsByClassName('buybutton');
    //This will hide all matching elements except the first one
    for (var i = 0; i < innerDiv1.length; i++) {
        var a = innerDiv1[i];
        a.style.display = 'none';
    }
    fetch(`../api/Products/SelectProductByStoreIDAsync/${id}`)
        .then(res => res.json())
        .then(data => {
            console.log(data)
            for (let i = 0; i < data.length; i++) {
                listofproductsdiv.innerHTML += `<p class="product">${data[i].name}   $${data[i].price}</p>  
                                                <button id=${data[i].productKey}class="product" class="buybutton" onclick="addtocart(${data[i].productKey})">Add To Cart</button>`;
            }
            if (button == false) {
                submitdiv.innerHTML += `<button id="submit" onclick="submit()"> Submit</button>`;
                button = true;
            }
        })
   
}

var itemsincart = 1;
function addtocart(i) {
    sessionStorage.setItem(`productKey${itemsincart}`, i)
    itemsincart++;
}


function submit() {
    if (sessionStorage.getItem(re)) {
        console.log('found')
    }
}

