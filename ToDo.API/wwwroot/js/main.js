$(function () { //shorthand document.ready function

    fetchData();



    function fetchData() {
        Ajax("API/ToDo", "GET", "", null).done(function (res) {
            res.forEach(function (item) {
                addTask(item);
            });
        });
    }

    function addTask(data) {
        $("#listGroup").prepend(getToDoDiv(data.id, data.tittle, data.done));
    }

    function getToDoInformation(parent) {
        var tittle = $(parent).find(".toDoName").text();
        var id = $(parent).attr('id');
        var done = $(parent).hasClass('done');

        return { tittle, id, done };
    }

    function updateToDoInformation(parent, tittle, done) {
        $(parent).find('.toDoName').html(tittle);
        if (done === false)
            $(parent).removeClass('done');
        else
            $(parent).addClass('done');
    }


    function getToDoDiv(id, tittle, done) {

        var doneCss = (done === true) ? 'done' : '';


        var toDoElement = "<li class='list-group-item d-flex justify-content-between align-items-center " + doneCss + "' id=" + id + ">" +
            "<div class='toDoName'>" +
            tittle +
            "</div>" +
            "<div class='align-items-right'>" +
            "<span class='badge badge-success doneToDo'>" +
            "<i class='fas fa-check'></i>" +
            "</span>" +
            "<span class='badge badge-primary editToDo'>" +
            "<i class='fas fa-edit'></i>" +
            "</span>" +
            "<span class='badge badge-danger removeToDo'> " +
            "<i class='fas fa-trash-alt '></i>" +
            "</span>";

        return toDoElement;
    }





    $(document).on('click', '.editToDo', function (e) {

        var parent = $(this).closest('li');
        var information = getToDoInformation(parent);
        var formExist = parent.find('.editToDoForm');
        var name = parent.find('.toDoName');


        if (formExist.length > 0) {
            $(formExist).remove();
            $(name).removeClass("hidden");
        } else {
            $(name).addClass("hidden");


            var formDiv = "<form class='form-inline justify-content-center editToDoForm' >" +
                "<div class='input-group mb-2 mr-sm-2 mb-sm-0'>" +
                "<input type='text' class='form-control' id='tittle' placeholder='New task name'  value ='" + information.tittle + "'/>" +
                "</div>" +
                "<button type='submit' class='btn btn-primary my-2 my-sm-0'>Rename Task </button>" +
                "</form>";

            $(parent).prepend(formDiv);
        }





    });


    $(document).on('submit', '.editToDoForm', function (e) {

        e.preventDefault();
        var parent = $(this).closest('li');
        var value = $(this).find(".form-control").val();
        var information = getToDoInformation(parent);

        Ajax("/API/ToDo/" + information.id, { tittle: value, done: information.done }, "PUT", null).done(function () {
            updateToDoInformation(parent, value, information.done);
        });

        parent.find('.toDoName').removeClass("hidden");
        $(this).remove();
    });



    $(document).on('click', '.removeToDo', function (e) {
        var parent = $(this).closest('li');
        var id = parent.attr('id');

        Ajax("/API/ToDo/" + id, "", "DELETE", null).done(function () {
            $(parent).remove();
        });


    });


    $(document).on('click', '.doneToDo', function (e) {

        var parent = $(this).closest('li');
        var information = getToDoInformation(parent);
        var newDoneState = (information.done === true) ? false : true;
        var temp = { tittle: information.tittle, done: newDoneState };

        Ajax("/API/ToDo/" + information.id, temp, "PUT", null).done(function () {
            updateToDoInformation(parent, information.tittle, newDoneState);
        });



    });

    $('#addTaskFrom').on('submit', function (e) {
        e.preventDefault();
        var value = $("#name").val();

        var temp = { tittle: value };

        Ajax("/API/TODO", temp, "POST", addTask);


    });


    function Ajax(url, data, method, callbackSuccess) {
        return $.ajax
            ({
                method: method,
                crossDomain: true,
                url: url,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(data),
                success: callbackSuccess,
                error: function (xhr) {
                    addError(errorToText(xhr.responseText));
                }
            });
    }

    function addError(message) {
        var errorDiv = "<div class='alert alert-danger alert - dismissible fade show' role='alert'>" + message +
            "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'>" +
            "<span aria-hidden='true'>&times;</span>" +
            "</button>" +
            "</div>";
        $("#errorHolder").prepend(errorDiv);
    }

    function errorToText(message) {
        if (message === 'TITTLE_IS_REQUIRED') {
            return "PLEASE PROVIDE TITTLE";
        } else if (message === 'NOT_EXIST') {
            return "SELECTED ITEM NOT EXIST";
        } else {
            return "UNKNOWN ERROR";
        }
    }


});
