
$(document).ready(function () {

    $('#CreatePersonaForm').validate({
        rules: {
            NombreC: {
                required: true
            },
            CorreoC: {
                required: true
            },
            EdadC: {
                required: true
            }
        },
        messages: {
            NombreC: {
                required: "Proporcione un nombre"
            },
            CorreoC: {
                required: "Proporcione un correo"
            },
            EdadC: {
                required: "Proporcione una edad"
            }
        },
        submitHandler: function (form) {
            return false;
        }
    });

    $('#UpdatePersonaForm').validate({
        rules: {
            NombreU: {
                required: true
            },
            CorreoU: {
                required: true
            },
            EdadU: {
                required: true
            }
        },
        messages: {
            NombreU: {
                required: "Proporcione un nombre"
            },
            CorreoU: {
                required: "Proporcione un correo"
            },
            EdadU: {
                required: "Proporcione una edad"
            }
        },
        submitHandler: function (form) {
            return false;
        }
    });
});

function GetDetallesPersona(Id, opcion) {
    event.preventDefault();
    $.ajax({
        type: "GET",
        url: "/PersonaById/" + Id,
        success: function (response) {
            if (opcion == 'Editar') {
                $("#Id").val(response.id);
                $("#NombreU").val(response.nombre);
                $("#CorreoU").val(response.correo);
                $("#EdadU").val(response.edad);
                $('#Update').modal('show');
            } else {
                $("#NombreD").val(response.nombre);
                $("#CorreoD").val(response.correo);
                $("#EdadD").val(response.edad);
                $('#Detalles').modal('show');
            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}

function CreatePersona() {
    event.preventDefault();

    var validacionCreate = $("#CreatePersonaForm").valid();

    if (validacionCreate != false) {
        Swal.fire({
            title: '¿Desea Guardar?',
            text: "¡No se podrá revertir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.value) {

                var per = {
                    Nombre: $("#NombreC").val(),
                    Correo: $("#CorreoC").val(),
                    Edad: $("#EdadC").val()
                }

                $.ajax({
                    type: "POST",
                    url: "/CreatePersona",
                    data: { persona: per },
                    beforeSend: function () {
                        $("#btnCreatePersona").prop("disabled", true);
                        Swal.fire({
                            title: 'Guardando...',
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            showConfirmButton: false,
                            onOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (data) {
                        Swal.fire(
                            '¡Guardado!',
                            'Persona añadida.',
                            'success'
                        ).then((result) => {
                            location.reload();
                        });
                    }
                });
            }
        });
    }
}

function UpdatePersona() {
    event.preventDefault();

    var validacionUpdate = $("#UpdatePersonaForm").valid();

    if (validacionUpdate != false) {
        Swal.fire({
            title: '¿Desea Guardar?',
            text: "¡No se podrá revertir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.value) {

                var per = {
                    Id: $("#Id").val(),
                    Nombre: $("#NombreU").val(),
                    Correo: $("#CorreoU").val(),
                    Edad: $("#EdadU").val()
                }

                $.ajax({
                    type: "POST",
                    url: "/UpdatePersona",
                    data: { persona: per },
                    beforeSend: function () {
                        $("#btnUpdatePersona").prop("disabled", true);
                        Swal.fire({
                            title: 'Guardando...',
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            showConfirmButton: false,
                            onOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (data) {
                        Swal.fire(
                            'Listo',
                            '¡Se ha actualizado con éxito!.',
                            "success"
                        ).then((result) => {
                            location.reload();
                        });
                    }
                });
            }
        });
    }
}

function RemovePersona(Id) {
    event.preventDefault();
    Swal.fire({
        title: '¿Está seguro?',
        text: "¡Se eliminará el registro!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.value) {

            $.ajax({
                type: "POST",
                url: "/RemovePersona?Id=" + Id,
                beforeSend: function () {
                    Swal.fire({
                        title: 'Eliminando...',
                        allowEscapeKey: false,
                        allowOutsideClick: false,
                        showConfirmButton: false,
                        onOpen: () => {
                            Swal.showLoading();
                        }
                    });
                },
                success: function (response) {
                    Swal.fire(
                        '¡Eliminado!',
                        'Registro eliminado.',
                        'success'
                    ).then((result) => {
                        location.reload();
                    })
                }
            });
        }
    })
}
