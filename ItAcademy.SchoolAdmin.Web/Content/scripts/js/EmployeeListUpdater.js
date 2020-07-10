var EmployeeListUpdater = (function () {

    function parsePhones(phones) {
        var string = '';
        $.each(phones,
            (index, phone) => {
                string += phone + '<br/>';
            });
        return string;
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
                            employee.ConvertedDate +
                            '</td>' +
                            '<td>' +
                            (employee.Email || '') +
                            '</td>' +
                            '<td>' +
                            ////(employee.Phone || '') +
                            ////'</td>' +
                            ////'<td>' +
                            parsePhones(employee.Phones) +
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