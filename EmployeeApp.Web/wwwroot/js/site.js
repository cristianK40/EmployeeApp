// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$("#employeeId").on("input", function () {
    let value = $(this).val();

    $(this).val(value.replace(/\D/g, ""));
});

$("#searchBtn").click(() =>
{
    $("#employeeResults").empty();
    let textValue = Number($("#employeeId").val());
    if (!isNaN(textValue) && textValue > 0)
    {
        $.ajax({
            url: `http://localhost:5242/EmployeeApi/GetEmployeeById/${textValue}`,
            success: function (response) {
                if (typeof response === "object")
                {
                    var rowHtml = `
                    <div class="row text-center border border-dark">
                    <div class="col-2 border border-dark p-2">${response.id}</div>
                    <div class="col-2 border border-dark p-2">${response.employee_name}</div>
                    <div class="col-2 border border-dark p-2">$${response.employee_salary}</div>
                    <div class="col-2 border border-dark p-2">${response.employee_age}</div>
                    <div class="col-2 border border-dark p-2">👤</div>
                    <div class="col-2 border border-dark p-2">$${response.employee_anual_Salary}</div>
                    </div>`;

                    $("#employeeResults").append(rowHtml);
                }
                else
                {
                    $("#employeeResults").html(`<div class="text-center text-danger">${response}</div>`);
                }
            },
            error: function (error) {
                $("#employeeResults").html(`<div class="text-center text-danger">Error retrieving employee.</div>`);
                console.log(error);
            }
        });
    }
    else
    {
        $.ajax({
            url: "http://localhost:5242/EmployeeApi/GetAllEmployess",
            success: function (response) {
                if (Array.isArray(response) && response.length > 0) {
                    var rowHtml = "";
                    response.forEach(employee => {
                    rowHtml += `
                    <div class="row text-center border border-dark">
                    <div class="col-2 border border-dark p-2">${employee.id}</div>
                    <div class="col-2 border border-dark p-2">${employee.employee_name}</div>
                    <div class="col-2 border border-dark p-2">$${employee.employee_salary}</div>
                    <div class="col-2 border border-dark p-2">${employee.employee_age}</div>
                    <div class="col-2 border border-dark p-2">👤</div>
                    <div class="col-2 border border-dark p-2">$${employee.employee_anual_Salary}</div>
                    </div>`;
                    });

                    $("#employeeResults").html(rowHtml);
                }
                else {
                    $("#employeeResults").html(`<div class="text-center text-danger">${response}</div>`);
                }
            },
            error: function (error) {
                $("#employeeResults").html(`<div class="text-center text-danger">Error retrieving employee.</div>`);
                console.log(error);
            }
        });
    }
    console.log(textValue);
});




