var EmployeeListUpdater = (function () {
    function toFormattedDate(dateString) {
        const date = new Date(dateString);
        return date.toLocaleDateString();
    }

    return function (options) {
        return {
            updateData: function (employees) {
                console.log(employees)
                var tbody = $('<tbody></tbody>');
                $.each(employees,
                    (index, employee) => {
                        tbody.append('<tr>' +
                            '<td>' +
                            employee.FullName +
                            '</td>' +
                            '<td>' +
                            toFormattedDate(employee.BirthDate) +
                            '</td>' +
                            '<td>' +
                            (employee.Email || '') +
                            '</td>' +
                            '<td>' +
                            (employee.Phone || '') +
                            '</td>' +
                            '<td>' +
                            options.urlsCellTemplate.replace(/_id_/g, employee.Id) +
                            '</td></tr>');
                    });
                options.employeeTableBody.replaceWith(tbody);
                options.employeeTableBody = tbody;
            }
        }
    };
}());