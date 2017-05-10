// Write your Javascript code.

$(document).ready(function () {

    // Render sideNav bar
    $(".button-collapse").sideNav();

    // Render select lists
    $('select').material_select();

    // Enable character counter validation
    $('char_chount').characterCounter();

    // Enable collapsible ul structure in "Edit" view
    $('.collapsible').collapsible();

    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 30, // Creates a dropdown of 15 years to control year
        max: true
    });

    // Enable delete modal to be triggered
    $('.modal').modal({
        dismissible: true, //Closed by clicking outside
        inDuration: 500, // Transition in duration
        outDuration: 500, // Transition out duration
        opacity: .5,
        complete: function () {
            console.log("Modal closed");
        }
    });

    // Enable modal close on cancel button click
    $('.modal-close').on('click', function () {
        $('.modal').modal('close')
    })
});
