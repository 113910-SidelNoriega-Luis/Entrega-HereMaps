

$("#btnsubmit").on("click", async function (event) {
    event.preventDefault();

    let Usuario = $("#txtNombre").val();

    let password = $("#txtContra").val();

    let bandera = true;

    if (Usuario == "") {
        alert("Usuario Vacio");
        bandera = false;
    }
    if (password == "") {

        alert("Contraseña vacia");
        bandera = false;
    }


    if (bandera) {
        const data =
        {
            "nombreUsuario": Usuario,
            "password": password
        }

        await Login(data);

    }

});



async function Login(data) {

    const url = "https://localhost:7038/loginUsuario";

    try {
        const response = await fetch(url,
            {
                method: "POST",
                headers:
                {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

        if (response.ok) {
            Swal.fire({
                title: 'Genial!',
                text: 'Ingreso Correcto.',
                imageUrl: 'puppy-coding.jpg',
                imageWidth: 400,
                imageHeight: 300,
                imageAlt: 'Custom image',
                showConfirmButton: false,
                timer: 3000,
                onOpen: () => {
                  Swal.showLoading();
                  setTimeout(() => {
                    Swal.close();
                    window.location.href = 'mapa.html';
                  }, 3000);
                }
            });
            
        } else {

            alert("Error");
        }

    }
    catch (e) {
        console.error(e);
        alert("Verifique que la api este encendida");

    }
}

