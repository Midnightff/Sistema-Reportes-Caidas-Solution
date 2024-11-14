﻿let table = new DataTable('#dt2', {
     pageLength: 5,
     lengthMenu: [5, 10, 15, 20],
     ordering: true,
     pagingType: "full_numbers"
 });

document.addEventListener("DOMContentLoaded", function () {
    window.confirmarEliminacion = function (formId) {
        Swal.fire({
            title: '¿Estás seguro?',
            text: "¡Esta acción no se puede deshacer!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                document.getElementById(formId).submit();
            }
        });
    };
});
