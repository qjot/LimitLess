$(function () {

    $("#calendar").fullCalendar({
        header: {
            left: "prev, next today",
            center: "title",
            right: "agendaWeek"
        },
        //theme: true,
        allDaySlot: false,
        axisFormat: "H:MM",
        minTime: "07:00:00",
        maxTime: "22:00:00",
        defaultView: "agendaWeek",
        editable: false,
        slotMinutes: 15,
        locale: "en-gb",
        events: "/Events/GetEvents/",
        eventClick: function (event, calEvent, jsEvent, view) {
            ClearEventInfoPopup();
            $("#classesType").text(event.title);
            $("#classesDescription").text(event.description);
            $("#startSpan").text(event.start);
            $("#lastSpan").text(event.end);
            $("#hallSpan").text(event.hallName);
            $("#availableSpan").text(event.capacity);
            $("#eventIdSpan").text(event.id);
            showEventInfoPopUp();
        },


        dayClick: function (date, allDay, jsEvent, view) {
            $("#eventTitle").val("");
            $("#eventDate").val(moment(date, "dd/MM/YY").format("L"));
            $("#eventTime").val(moment(date, "HH:mm").format("LT"));
            ShowEventPopup(date);
        },
        eventRender: function (event, element) {
            element.find(".fc-title").append("<br/>" + event.trainerName +
            "<br/>" + event.hallName +
            "<br/>" + event.capacity
                );

        }


    });


    $("#btnPopupCancel").click(function () {
        ClearPopupFormValues();
        $("#popupEventForm").hide();
    });

    $("#btnPopupSave").click(function () {

        $("#popupEventForm").hide();

        var dataRow = {
            "title": $("#eventTitle").val(),
            "newEventDate": $("#eventDate").val(),
            "newEventTime": $("#eventTime").val(),
            "newEventDuration": $("#eventDuration").val(),
            "trainerId": $("#trainerSelectable").val(),
            "classesTypeId": $("#classesSelectable").val(),
            "hallId": $("#hallSelectable").val(),
        }

        ClearPopupFormValues();

        $.ajax({
            type: "POST",
            url: "/Events/SaveEvent",
            data: dataRow,
            success: function (response) {
                if (response == "True") {
                    $("#calendar").fullCalendar("refetchEvents");
                    alert("New event saved!");
                }
                else {
                    alert("Error, could not save event!");
                }
            }
        });
    });




    function showEventInfoPopUp() {

        $("#popUpEventInfo").modal("show");
    }
    function ShowEventPopup(date) {
        ClearPopupFormValues();
        $("#popupEventForm").modal("show");
        $("#eventTitle").focus();
    }

    function ClearPopupFormValues() {
        $("#eventID").val("");
        $("#eventTitle").val("");
        $("#eventDateTime").val("");
        $("#eventDuration").val("");
    }
    function ClearEventInfoPopup() {
        $("#classesType").val("");
        $("#classesDescription").val("");
        $("#startSpan").val("");
        $("#lastSpan").val("");
        $("#hallSpan").val("");
        $("#availableSpan").val("");
    }


});