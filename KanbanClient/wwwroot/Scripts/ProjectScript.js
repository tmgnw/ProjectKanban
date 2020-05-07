var dateNow = new Date();
var User = [];
$(document).ready(function () {
    $('#Project').dataTable({
        "ajax": {
            url: "/Project/LoadProject",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        "columnDefs": [
            { "orderable": false, "targets": 4 },
            { "searchable": false, "targets": 4 }
        ],
        "columns": [
            { data: "name" },
            { data: "manager" },
            { data: "description" },
            {
                data: "createDate", render: function (data) {
                    return moment(data).format('DD/MM/YYYY, h:mm a');
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<td><div class='btn-group'><button type='button' title='Task List' id='BtnTask' data-original-title='TaskList' data-placement='top' data-toggle='tooltip' class='btn btn-primary'><i class='fa fa-tasks'></i></button><button type='button' class='btn btn-warning' id='BtnEdit' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit' onclick=GetById('" + row.id + "');><i class='fa fa-pencil'></i></button> <button type='button' title='Delete' class='btn btn-danger' id='BtnDelete' data-toggle='tooltip' data-placement='top' data-original-title='Delete' onclick=Delete('" + row.id + "');><i class='fa fa-trash'></i></button></div></td>";
                }
            },
        ]
    });


    // tooltip
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

    //load table manager
    LoadUser($('#UserOption'));
}); 
/*--------------------------------------------------------------------------------------------------*/
// Selectlist
function LoadUser(element) {
    if (User.length === 0) {
        $.ajax({
            type: "Get",
            url: "/User/LoadUser",
            success: function (data) {
                User = data.data;
                renderUser(element);
            }
        });
    }
    else {
        renderUser(element);
    }
}

// Memasukan Loaduser ke dropdown
function renderUser(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select User').hide());
    $.each(User, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.fullName));
    });
} 
/*--------------------------------------------------------------------------------------------------*/
//fungsi btn add
document.getElementById("BtnAdd").addEventListener("click", function () {
    ClearScreen();
    $('#SaveBtn').show();
    $('#UpdateBtn').hide();
    LoadUser($('#UserOption'));
}); 

/*--------------------------------------------------------------------------------------------------*/
//clear field
function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Description').val('');
    $('#UserOption').val('');
    LoadUser($('#UserOption'));
} 
/*--------------------------------------------------------------------------------------------------*/
 //get id to edit
function GetById(Id) {
    debugger;
    $.ajax({
        url: "/Project/GetById/"+ Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            $('#Id').val(result.id);
            $('#Name').val(result.name);
        //    $('#UserOption').val(result.manager_Id);
            $('#Description').val(result.description);
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
    var Project = new Object();
    Project.Name = $('#Name').val();
    Project.Manager_Id = $('#UserOption').val();
    Project.Description = $('#Description').val();
    $.ajax({
        type: 'POST',
        url: '/Project/InsertOrUpdate',
        data: Project
    }).then((result) => {
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                potition: 'center',
                title: 'Project Add Successfully',
                timer: 2500
            }).then(function () {
                $('#Project').DataTable().ajax.reload();
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
    var Project = new Object();
    Project.Id = $('#Id').val();
    Project.Name = $('#Name').val();
   // Project.Manager_Id = $('#UserOption').val();
    Project.Description = $('#Description').val();
    $.ajax({
        type: 'POST',
        url: '/Project/InsertOrUpdate',
        data: Project
    }).then((result) => {
        if (result.statusCode === 200) {
            Swal.fire({
                icon: 'success',
                potition: 'center',
                title: 'Project Updated Successfully',
                timer: 2500
            }).then(function () {
                $('#Project').DataTable().ajax.reload();
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
                url: "/Project/Delete/",
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
                        $('#Project').DataTable().ajax.reload();
                        cls();
                        $('#Project').modal('hide');
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