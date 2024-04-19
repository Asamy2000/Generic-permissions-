$(document).ready(function () {
    $('#Image').on('change', function () {
        var coverPreview = $('.cover-preview');
        var fileInput = this;

        if (fileInput.files.length > 0) {

            coverPreview.attr('src', window.URL.createObjectURL(fileInput.files[0]));
            coverPreview.removeClass('d-none');
        } else {

            coverPreview.attr('src', '');
            coverPreview.addClass('d-none');
        }
    });
});