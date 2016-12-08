
$(function () {
    
    $("#calendar").fullCalendar({
        header: {
            left: "prev, next today",
            center: "title",
            right: "agendaWeek, agendaDay"
        },
        //theme: true,
        allDaySlot: false,
        axisFormat: "H(:mm)",
        minTime: "07:00:00",
        maxTime: "22:00:00",
        defaultView: "agendaWeek",
        editable: true,
        slotMinutes: 15,
        locale: "en-gb",
        events: "/Events/GetEvents/",
        eventClick: function (calEvent, jsEvent, view) {
                alert("You clicked on event id: " + calEvent.id
                    + "\nDescription: " + calEvent.description
                    + "\nAnd the title is: " + calEvent.title);

            },

            eventDrop: function (event, dayDelta, minuteDelta, allDay, revertFunc) {
                if (confirm("Confirm move?")) {
                    UpdateEvent(event.id, event.start,event.end);
                }
                else {
                    revertFunc();
                }
            },

            eventResize: function (event, dayDelta, minuteDelta, revertFunc) {

                if (confirm("Confirm change appointment length?")) {
                    UpdateEvent(event.id, event.start, event.end);
                }
                else {
                    revertFunc();
                }
            },
            dayClick: function (date, allDay, jsEvent, view) {
                $("#eventTitle").val("");
                $("#eventDate").val(moment(date,"dd/MM/YY").format("L"));
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

    function UpdateEvent(EventID, EventStart, EventEnd) {

        var dataRow = {
            "ID": EventID,
            "NewEventStart": EventStart,
            "NewEventEnd": EventEnd
        }

        $.ajax({
            type: "POST",
            url: "/Events/UpdateEvent",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dataRow)
        });
    }
});