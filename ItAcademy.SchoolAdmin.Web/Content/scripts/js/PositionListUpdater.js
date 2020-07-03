var PositionListUpdater = (function () {
    return function (options) {
        return {
            updateData: function (positions) {
                console.log(positions)
                var tbody = $('<tbody></tbody>');
                $.each(positions,
                    (index, position) => {
                        tbody.append('<tr>' +
                            '<td>' +
                            position.Name +
                            '</td>' +
                            '<td>' +
                            (position.MaxEmployees || '') +
                            '</td>' +
                            '<td>' +
                            options.urlsCellTemplate.replace(/_id_/g, position.Id) +
                            '</td></tr>');
                    });
                options.positionTableBody.replaceWith(tbody);
                options.positionTableBody = tbody;
            }
        }
    };
}());