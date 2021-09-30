const loginform = document.querySelector(".loginform");

loginform.addEventListener('submit', (e) => {
    e.preventDefault();
    const fname = loginform.fname.value;
    //const lname = loginform.lname.value;

    fetch(`../api/customers/onLogin/${fname}`)
        .then(res => res.json())
            .then(res => {
                console.log(res)
                sessionStorage.setItem('user', JSON.stringify(res));
                location.href = `../html/storeselect.html`

            })
});


