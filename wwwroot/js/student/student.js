$(document).ready(function () {
    $('select').material_select();

    $('.datepicker').pickadate({
        selectMonths: true, 
        selectYears: 25,
        formatSubmit: 'yyyy-mm-dd',
    });

    $('input#fiscalcode').characterCounter();  

});
