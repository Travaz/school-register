$(document).ready(function () {
    $('select').material_select();

    $('.datepicker').pickadate({
        selectMonths: true, 
        selectYears: 15,
        format: 'dd/mm/yyyy',
        formatSubmit: 'yyyy-mm-dd'
    });
});