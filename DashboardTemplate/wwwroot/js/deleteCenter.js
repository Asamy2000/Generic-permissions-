$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'هل أنت متأكد من أنك بحاجة إلى حذف هذا المركز',
            text: "!لن تتمكن من التراجع عن هذ",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم، قم بحذفه',
            cancelButtonText: 'لا، إلغاء',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/AccreditedCenter/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'تم الحذف',
                            'تم حذف المركز',
                            'success'
                        );

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});