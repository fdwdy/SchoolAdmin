$(document).ready(function () {

    var handler = new SearchHandler("employee", "search");

    $('#search').on('input', function () {
        return showResults(handler, false)
    });

    $('#search').on('keyup', function () {
        return showResults(handler, false)
    });

    $('#search').on('paste', function () {
        return showResults(handler, false)
    });

    $('#submit').click(function () {
        return showResults(handler, true)
    });

    function showResults(handler, enableShortSearch) {

        var query = $('#search').val();

        query = encodeURIComponent(query);

        if (query.length < 3 && !enableShortSearch) {
            return
        }

        if (handler.xhr.readyState != 4) {
            handler.xhr.abort();
        }

        handler.setQuery(query);
        handler.processQuery();
    };
});

class SearchHandler {

    prevQuery = '';

    query = '';

    xhr = new XMLHttpRequest();

    url = '';

    constructor(controller, action, updater) {
        this.updater = updater;
        this.controllerName = controller;
        this.actionName = action;
    }

    setQuery(query) {
        this.query = query;
    }

    getConnectionString() {
        this.url = "http://localhost:13693/" + this.controllerName + "/" + this.actionName + "?";
        console.log(this.url)
    }

    processQuery() {

        if (this.query == this.prevQuery) {
            return;
        }

        this.xhr = $.ajax(this.url, {
            data: "query=" + this.query,
            timeout: 300,
            success: function (data) {
                $('#results').html(data);
            }
        });

        this.prevQuery = this.query;

    };
}