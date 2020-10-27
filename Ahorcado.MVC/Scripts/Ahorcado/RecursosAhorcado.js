function testearConexion() {
    console.log("Conexion establecida");
}

function ingresarPalbraAAdivinar(Palabra) {
    var yo = this;
    console.log("Entro aca");
    $.ajax({
        url: "/Ahorcado/InsertePalabraAAdivinar",
        data: model = this,
        palabra = Palabra,
        success: function(result) {
            console.log(result)
        }
    })

}

