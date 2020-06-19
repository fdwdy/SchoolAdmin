$(function () {

    var hb = $.connection.employeeHub;

    hb.client.broadcast = function (message) {
        getAll();
    };

    $.connection.hub.start().done(function () {
        getAll();
    });

});

function getAll() {
    var query = $('#search').val();
    query = encodeURIComponent(query);
    if (query.length > 2) {
        $('#results').load("http://localhost:13693/Employee/Search?query=" + query);
        return;
    }
    var model = $('#results');
    $.ajax({
        url: '/Employee/GetEmployeeData',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    });
}