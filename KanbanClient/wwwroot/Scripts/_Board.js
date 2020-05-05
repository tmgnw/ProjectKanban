$(document).ready(function () {
    loadBoard();
});

function loadBoard() {
    $.ajax({
        url: "/Board/LoadBoard",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, Board) {
                html += '<tr>';
                html += '<div class="card" style="width: 18rem;">';
                html += '<div class="card-body">';
                html += '<h5 class="card-title">' + Board.Name + '</h5>';
                html += '<button type="Button" class="btn btn-warning" style="center" id="Goto">Goto</button>';
                html += '</div>';
                html += '</div>';
                html += '</tr>';
            });
            $('#BodyBoard').html(html);
        }
    })
}

