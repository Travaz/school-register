$(document).ready(function () {

    // Render select lists
    $('select').material_select();

    // Enable character counter validation
    $('input#fiscalcode').characterCounter();  

    // Enable collapsible ul structure in "Edit" view
    $('.collapsible').collapsible();

    // Enable delete modal to be triggered
    $('.modal').modal({
        dismissible: true, //Closed by clicking outside
        opacity: .5,
        complete: function () {
            console.log("Modal closed");
        }
    });

    $('.modal-close').on('click', function () {
        $('.modal').modal('close')
    })
});
