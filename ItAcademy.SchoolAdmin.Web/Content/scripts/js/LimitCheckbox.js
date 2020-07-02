$(document).ready(function () {
    countChecked()
});

function countChecked() {
    var n = $("input:checked").length;
    var maxEmployees = document.getElementById('maxEmployees').value;
    if (n == maxEmployees) {
        $(':checkbox:not(:checked)').prop('disabled', true);
    }
    else {
        $(':checkbox:not(:checked)').prop('disabled', false);
    }
}
$(":checkbox").click(countChecked);
