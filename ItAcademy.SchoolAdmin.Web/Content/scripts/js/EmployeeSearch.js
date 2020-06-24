$(document).ready(function () {

    handler = new SearchHandler();

    $('#search').on('focusin', function () {
        $('#search').val('');
    });

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

    constructor() {

    }

    setQuery(query) {
        this.query = query;
    }

    processQuery() {

        if (this.query == this.prevQuery) {
            return;
        }

        this.xhr = $.ajax("http://localhost:13693/Employee/Search?", {
            data: "query=" + this.query,
            timeout: 300,
            success: function (data) {
                $('#results').html(data);
            }
        });

        this.prevQuery = this.query;

    };
}