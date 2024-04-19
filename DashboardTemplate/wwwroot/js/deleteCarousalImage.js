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
            title: 'هل أنت متأكد من أنك بحاجة إلى حذف هذه الصوره',
            text: "!لن تتمكن من التراجع عن هذ",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'نعم، قم بحذفه',
            cancelButtonText: 'لا، إلغاء',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Carousal/DeleteImage/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'تم الحذف',
                            'تم حذف الصوره',
                            'success'
                        ).then(() => {
                            
                            window.location.reload();
                        });

                        
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