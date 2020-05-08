var dateNow = new Date();
var Project = [];
$(document).ready(function () {
    //load digram
    Donut();
    Bar();
    $('#TaskList').dataTable({
        "ajax": {
            url: "/TaskList/LoadTaskList",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [
            { "orderable": false, "targets": 4 },
            { "searchable": false, "targets": 4 }
        ],
        dom: 'Bfrtip',
        buttons: [
            'csv', 'excel', 'pdf'
        ],
        "columns": [
            { data: "name" },
            { data: "project" },
            { data: "status" },
            {
                data: "createDate", render: function (data) {
                    return moment(data).format('DD/MM/YYYY, h:mm a');
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<td><div class='btn-group'><button type='button'  title='Card' id='BtnCard' data-original-title='Card' data-placement='top' data-toggle='tooltip' class='btn btn-primary'><i class='fa fa-tasks'></i></button><button type='button' class='btn btn-warning' id='BtnEdit' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit' onclick=GetById('" + row.id + "');><i class='fa fa-pencil'></i></button> <button type='button' title='Delete' class='btn btn-danger' id='BtnDelete' data-toggle='tooltip' data-placement='top' data-original-title='Delete' onclick=Delete('" + row.id + "');><i class='fa fa-trash'></i></button></div></td>";
                }
            },
        ]
    });


    // tooltip
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

    //load table manager
    LoadProject($('#ProjectOption'));
});
/*--------------------------------------------------------------------------------------------------*/
// Selectlist
function LoadProject(element) {
    if (Project.length === 0) {
        $.ajax({
            type: "Get",
            url: "/Project/LoadProject2",
            success: function (data) {
                Project = data.data;
                renderProject(element);
            }
        });
    }
    else {
        renderProject(element);
    }
}

// Memasukan Loaduser ke dropdown
function renderProject(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Project').hide());
    $.each(Project, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name));
    });
}
/*--------------------------------------------------------------------------------------------------*/
//fungsi btn add
document.getElementById("BtnAdd").addEventListener("click", function () {
    ClearScreen();
    $('#SaveBtn').show();
    $('#UpdateBtn').hide();
    LoadProject($('#ProjectOption'));
});

/*--------------------------------------------------------------------------------------------------*/
//clear field
function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Status').val('');
    $('#ProjectOption').val('');
    LoadProject($('#ProjectOption'));
}
/*--------------------------------------------------------------------------------------------------*/
//get id to edit
function GetById(Id) {
    debugger;
    $.ajax({
        url: "/TaskList/GetById/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            $('#Id').val(result.id);
            $('#Name').val(result.name);
            $('#ProjectOption').val(result.project_Id);
            $('#Status').val(result.status);
            $('#myModal').modal('show');
            $('#UpdateBtn').show();
            $('#SaveBtn').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responsText);
        }
    })
}

//function save
function Save() {
    var TaskList = new Object();
    TaskList.Name = $('#Name').val();
    TaskList.Project_Id = $('#ProjectOption').val();
    TaskList.Status = $('#Status').val();
    $.ajax({
        type: 'POST',
        url: '/TaskList/InsertOrUpdate',
        data: TaskList
    }).then((result) => {
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                potition: 'center',
                title: 'TaskList Add Successfully',
                timer: 2500
            }).then(function () {
                $('#TaskList').DataTable().ajax.reload();
                $('#myModal').modal('hide');
                ClearScreen();
            });
        }
        else {
            Swal.fire('Error', 'Failed to Input', 'error');
        }
    })
}

//function edit
function Edit() {
    debugger;
    var TaskList = new Object();
    TaskList.Id = $('#Id').val();
    TaskList.Name = $('#Name').val();
    TaskList.Project_Id = $('#ProjectOption').val();
    TaskList.Status = $('#Status').val();
    $.ajax({
        type: 'POST',
        url: '/TaskList/InsertOrUpdate',
        data: TaskList
    }).then((result) => {
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                potition: 'center',
                title: 'TaskList Updated Successfully',
                timer: 2500
            }).then(function () {
                $('#TaskList').DataTable().ajax.reload();
                $('#myModal').modal('hide');
                ClearScreen();
            });
        }
        else {
            Swal.fire('Error', 'Failed to Input', 'error');
        }
    })
}

/*--------------------------------------------------------------------------------------------------*/

//function delete
function Delete(Id) {
    debugger;
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.value) {
            //debugger;
            $.ajax({
                url: "/TaskList/Delete/",
                data: { Id: Id }
            }).then((result) => {
                debugger;
                if (result.statusCode == 200) {
                    Swal.fire({
                        icon: 'success',
                        position: 'center',
                        title: 'Delete Successfully',
                        timer: 2000
                    }).then(function () {
                        $('#TaskList').DataTable().ajax.reload();
                        $('#myModal').modal('hide');
                        ClearScreen();
                    });
                }
                else {
                    Swal.fire({
                        icon: 'error',
                        title: 'error',
                        text: 'Failed to Delete',
                    })
                    ClearScreen();
                }
            })
        }
    });
}

/*--------------------------------------------------------------------------------------------------*/
function Donut() {
    //debugger;
    $.ajax({
        type: 'GET',
        url: '/TaskList/GetChart/',
        success: function (data) {
            //debugger;
            Morris.Donut({
                element: 'DonutChart',
                data: $.each(JSON.parse(data), function (index, val) {
                    //debugger;
                    [{
                        label: val.label,
                        value: val.value
                    }]
                }),
                resize: true,
                colors: ['#009efb', '#55ce63', '#2f3d4a']
            });
        }
    })
};

//------------------------------------------------------------//
function Bar() {
    $.ajax({
        type: 'GET',
        url: '/TaskList/GetChart/',
        success: function (data) {
            Morris.Bar({
                element: 'BarChart',
                data: $.each(JSON.parse(data), function (index, val) {
                    //debugger;
                    [{
                        label: val.label,
                        value: val.value
                    }]
                }),
                xkey: 'label',
                ykeys: ['value'],
                labels: ['label'],
                barColors: ['#009efb', '#55ce63', '#2f3d4a'],
                hideHover: 'auto',
                gridLineColor: '#eef0f2',
                resize: true
            });
        }
    })
};