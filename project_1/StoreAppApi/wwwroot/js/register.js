
//const registerform = document.querySelector(".registerform");

//registerform.addEventListener('submit', (e) => {
//    e.preventDefault();
//    const fname = registerform.fname.value;
//    const userData = {CustomerId: -1, fname: name}

//    fetch(`../customers/onRegister`, { method: `POST`, body: JSON.stringify(userData) })
//        .then(res => res.json())
//        .then(res => {
//            console.log(res)
//            sessionStorage.setItem('user', JSON.stringify(res));
//            location.href = `storeselect.html`

//        })
//});

const registerform = document.querySelector(".registerform");

registerform.addEventListener('submit', (e) => {
    e.preventDefault();
    const fname = registerform.fname.value;
    //const email = registerform.email.value;
    const userData = { CustomerID: 10, Name: fname }

    //POST fetch request
    fetch(`../api/Customers/onRegister`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Network response was not ok(${ response.status })`);
            }
            else       // When the page is loaded convert it to text
                return response.json();
        })
        .then(res => {
            sessionStorage.setItem('user', JSON.stringify(res));//, json.stringify(res));
            let user = sessionStorage.getItem('user');
            console.log(sessionStorage.user);
            location.href = "storeselect.html";
        })
        //.then((jsonResponse) => {
        //    console.log(jsonResponse);

        //    location.href = "selectstore.html";
        //    return jsonResponse;
        //})

        .catch(function (err) {
            console.log('Failed to fetch page: ', err);
        });
});
