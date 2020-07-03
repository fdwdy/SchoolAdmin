var EmployeeListUpdater = (function () {
    return function (options) {
        return {
            updateData: function (employees) {
                console.log(employees)
                var tbody = $('<tbody></tbody>');
                $.each(employees,
                    (index, employee) => {
                        tbody.append('<tr>' +
                            '<td>' +
                            employee.Name +
                            '</td>' +
                            '<td>' +
                            options.urlsCellTemplate.replace(/_id_/g, employee.Id) +
                            '</td></tr>');
                    });
                options.subjectTableBody.replaceWith(tbody);
                options.subjectTableBody = tbody;
            }
        }
    };
}());