const uri = "Items" + "/";
const uriGetItems = uri + "GetItems";
let items = null;



function getCount(data) {
    const el = $("#counter");
    let name = "item";
    if (data) {
        if (data > 1) {
            name = "items";
        }
        el.text(data + " " + name);
    } else {
        el.text("No " + name);
    }
}

function getItems() {
    $.ajax({
        type: "GET",
        url: uriGetItems,
        cache: false,
        success: function (data) {
            const tBody = $("#titems");
            $(tBody).empty();

            getCount(data.length);
            $.each(data, function (key, item) {
                const tr = $("<tr></tr>")
                    .append($("<td></td>").text(item.name))
                    .append(
                    $("<td class='table-button-td'></td>").append(
                            $("<button>Edit</button>").on("click", function () {
                                editItem(item.id);
                            })
                        )
                    )
                .append(
                    $("<td class='table-button-td'></td>").append(
                        $("<button>Delete</button>").on("click", function () {
                            deleteItem(item.id);
                        })
                    )
                )
                tr.appendTo(tBody);
            });

            items = data;
        }
    });
}

function addItem() {
    const item = {
        name: $("#add-name").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getItems();
            $("#add-name").val("");
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + id,
        type: "DELETE",
        success: function (result) {
            getItems();
        }
    });
}

function editItem(id) {
    $.each(items, function (key, item) {
        if (item.id === id) {
            $("#edit-name").val(item.name);
            $("#edit-id").val(item.id);
        }
    });
    $("#spoiler").css({ display: "block" });
}


$("#my-form").submit(function () {
    const item = {
        name: $("#edit-name").val(),
        id: $("#edit-id").val()
    };

    $.ajax({
        url: uri + $("#edit-id").val(),
        type: "PUT",
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function (result) {
            getItems();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $("#spoiler").css({ display: "none" });
}


$(document).ready(function () {
    $("#table").hide();
    $("#loading").show();

    getItems();

    $("#loading").hide();
    $("#table").show(); 
});
