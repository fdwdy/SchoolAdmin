$(document).ready(function () {
    $('#search').on('input', showResults);
    $('#search').on('keyup', showResults);
    $('#search').on('paste', showResults);
});

function showResults(e) {
    var query = $('#search').val();
    query = encodeURIComponent(query);
    $('#results').load("http://localhost:13693/Employee/Search?query=" + query);
};