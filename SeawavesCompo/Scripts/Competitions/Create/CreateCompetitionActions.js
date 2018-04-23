var ViewModel = {};
//start actions
$(document).ready(function () {
    //define viewmodel function

    ViewModel = new CompetitionViewModelEdit();
    registerCustomBindingHandlers();
    ko.applyBindings(ViewModel);

    registerJQuery();
});


function submitToServer() {
    //do necessary
}
//control/gfx actions

function TranslateToTime(sliderVal) {
    switch (sliderVal) {
        case 1: return "1 Hour"; break;
        case 2: return "2 Hours"; break;
        case 3: return "4 Hours"; break;
        case 4: return "8 Hours"; break;
        case 5: return "12 Hours"; break;
        case 6: return "24 Hours"; break;
        case 7: return "2 Days"; break;
        case 8: return "3 Days"; break;
        case 9: return "4 Days"; break;
        case 10: return "5 Days"; break;
        case 11: return "6 Days"; break;
        case 12: return "7 Days"; break;
        case 13: return "2 Weeks"; break;
        case 14: return "3 Weeks"; break;
        case 15: return "4 Weeks"; break;
        case 16: return "3 Months"; break;
    }
}

//jquery controls
function registerJQuery() {
    //override datepicker defaults
    //$.datepicker.parseDate = function (format, value) {
    //    return moment(value, format).toDate();
    //}

    //$.datepicker.formatDate = function (format, value) {
    //    return moment(value).format(format);
    //}

    $('#compoDate').datetimepicker({ dateFormat: "MM-DD-YYYY" });
    $('#compoLength').slider();
}

function registerCustomBindingHandlers() {
    ko.bindingHandlers.datetimepicker = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            allBindings = allBindingsAccessor();

            var options = {
                format: 'MM/DD/YYYY hh:mm',
                defaultDate: ko.utils.unwrapObservable(valueAccessor())
            };

            ko.utils.extend(options, allBindings.dateTimePickerOptions)

            $(element).datetimepicker(options).on("change.dp", function (evntObj) {
                var observable = valueAccessor();
                if (evntObj.timeStamp !== undefined) {
                    var picker = $(this).data("DateTimePicker");
                    var d = picker.getDate();
                    observable(d.format(picker.format));
                }
            });
        },
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).data("DateTimePicker").setDate(value);
        }
    };
}