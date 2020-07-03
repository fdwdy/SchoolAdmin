var SubjectListUpdater = (function () {
    return function (options) {
        return {
            updateData: function (subjects) {
                console.log(subjects)
                var tbody = $('<tbody></tbody>');
                $.each(subjects,
                    (index, subject) => {
                        tbody.append('<tr>' +
                            '<td>' +
                            subject.Name +
                            '</td>' +
                            '<td>' +
                            options.urlsCellTemplate.replace(/_id_/g, subject.Id) +
                            '</td></tr>');
                    });
                options.subjectTableBody.replaceWith(tbody);
                options.subjectTableBody = tbody;
            }
        }
    };
}());