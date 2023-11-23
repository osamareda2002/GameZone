/*
$(document).ready(function () { 
            $('#Cover').on('change', function () {
                $('.cover-preview').attr)('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none')
            });
        });
*/

imgInp.onchange = evt => {
    const [file] = imgInp.files
    if (file) {
        blah.src = URL.createObjectURL(file)
    }
    $("img").removeClass("d-none");
    
}