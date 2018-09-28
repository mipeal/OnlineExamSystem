
(function ($)
{
    function padLeft(value, l, c)
    {
        return Array(l - value.toString().length + 1).join(c || " ") + value.toString();
    };
    
    $.fn.timesetter = function (options)
    {
        var wrapper = $(this);
        if (wrapper.find(".divTimeSetterContainer").length !== 1)
        {
            wrapper.html(htmlTemplate);
        }
        var container = wrapper.find(".divTimeSetterContainer");
        saveOptions(container, options);

        var btnUp = container.find('#btnUp');
        var btnDown = container.find('#btnDown');

        // binding events
        btnUp.unbind('click').bind('click', function (event) { updateTimeValue(this, event); });
        btnDown.unbind('click').bind('click', function (event) { updateTimeValue(this, event); });

        var txtHours = container.find('#txtHours');
        var txtMinutes = container.find('#txtMinutes');

        txtHours.unbind('focusin').bind('focusin', function (event) { $(this).select(); unitChanged(this, event); });
        txtMinutes.unbind('focusin').bind('focusin', function (event) { $(this).select(); unitChanged(this, event); });

        txtHours.unbind('keydown').bind('keydown', function (event) { updateTimeValueByArrowKeys(this, event); });
        txtMinutes.unbind('keydown').bind('keydown', function (event) { updateTimeValueByArrowKeys(this, event); });

        // apply formatting for input fields
        $(container).find("input[type=text]").each(function ()
        {
            $(this).change(function (e)
            {
                formatInput(e);
            });
        });

        // set default values
        if (txtHours.val().length === 0)
        {
            txtHours.val(padLeft($.fn.settings.hour.min.toString(), getMaxLength($.fn.settings.hour), $.fn.settings.numberPaddingChar));
        }

        if (txtMinutes.val().length === 0)
        {
            txtMinutes.val(padLeft($.fn.settings.minute.min.toString(), getMaxLength($.fn.settings.minute), $.fn.settings.numberPaddingChar));
        }

        var hourSymbolSpan = txtHours.siblings("span.hourSymbol:first");
        hourSymbolSpan.text($.fn.settings.hour.symbol);

        var minuteSymbolSpan = txtMinutes.siblings("span.minuteSymbol:first");
        minuteSymbolSpan.text($.fn.settings.minute.symbol);

        var postfixLabel = container.find(".postfix-position");
        postfixLabel.text($.fn.settings.postfixText);
        return this;
    };
    
    function unitChanged(sender)
    {
        var container = $(sender).parents(".divTimeSetterContainer");
        loadOptions(container);

        unit = $(sender).data("unit");

        $.fn.settings.inputHourTextbox = container.find('#txtHours');
        $.fn.settings.inputMinuteTextbox = container.find('#txtMinutes');

        saveOptions(container, $.fn.settings);
    };
    
    function updateTimeValue(sender)
    {
        var container = $(sender).parents(".divTimeSetterContainer");
        loadOptions(container);

        $.fn.settings.inputHourTextbox = container.find('#txtHours');
        $.fn.settings.inputMinuteTextbox = container.find('#txtMinutes');

        $.fn.settings.hour.value = parseInt($.fn.settings.inputHourTextbox.val());
        $.fn.settings.minute.value = parseInt($.fn.settings.inputMinuteTextbox.val());

        $.fn.settings.direction = $(sender).data("direction");

        // validate hour and minute values
        if (isNaN($.fn.settings.hour.value))
        {
            $.fn.settings.hour.value = $.fn.settings.hour.min;
        }

        if (isNaN($.fn.settings.minute.value))
        {
            $.fn.settings.minute.value = $.fn.settings.minute.min;
        }

        // update time setter by changing hour value
        if (unit === "hours")
        {
            var oldHourValue = parseInt($($.fn.settings.inputHourTextbox).val().trim());
            var newHourValue = 0;

            if ($.fn.settings.direction === "decrement")
            {
                newHourValue = oldHourValue - $.fn.settings.hour.step;

                // tolerate the wrong step number and move to a valid step
                if ((newHourValue % $.fn.settings.hour.step) > 0)
                {
                    newHourValue = (newHourValue - (newHourValue % $.fn.settings.hour.step)); // set to the previous adjacent step
                }

                if (newHourValue <= $.fn.settings.hour.min)
                {
                    newHourValue = $.fn.settings.hour.min;
                }
            }
            else if ($.fn.settings.direction === "increment")
            {
                newHourValue = oldHourValue + $.fn.settings.hour.step;

                // tolerate the wrong step number and move to a valid step
                if ((newHourValue % $.fn.settings.hour.step) > 0)
                {
                    newHourValue = (newHourValue - (newHourValue % $.fn.settings.hour.step)); // set to the previous adjacent step
                }

                if (newHourValue >= $.fn.settings.hour.max)
                {
                    newHourValue = $.fn.settings.hour.max - $.fn.settings.hour.step;
                }
            }

            $($.fn.settings.inputHourTextbox).val(padLeft(newHourValue.toString(), getMaxLength($.fn.settings.hour), $.fn.settings.numberPaddingChar));
            $(container).attr("data-hourvalue", newHourValue);
            $(container).attr("data-minutevalue", newMinuteValue);
            $($.fn.settings.inputHourTextbox).trigger("change").select();
        }
        else if (unit === "minutes") // update time setter by changing minute value
        {
            var oldHourValue = $.fn.settings.hour.value;
            var newHourValue = oldHourValue;

            var oldMinuteValue = $.fn.settings.minute.value;
            var newMinuteValue = oldMinuteValue;

            if ($.fn.settings.direction === "decrement")
            {
                newMinuteValue = oldMinuteValue - $.fn.settings.minute.step;

                // tolerate the wrong step number and move to a valid step
                if ((newMinuteValue % $.fn.settings.minute.step) > 0)
                {
                    newMinuteValue = (newMinuteValue - (newMinuteValue % $.fn.settings.minute.step)); // set to the previuos adjacent step
                }

                if (newHourValue <= $.fn.settings.hour.min &&
                    oldMinuteValue <= $.fn.settings.minute.min)
                {
                    newHourValue = $.fn.settings.hour.min;
                    newMinuteValue = $.fn.settings.minute.min;
                }
            }
            else if ($.fn.settings.direction === "increment")
            {
                newMinuteValue = oldMinuteValue + $.fn.settings.minute.step;

                // tolerate the wrong step number and move to a valid step
                if ((newMinuteValue % $.fn.settings.minute.step) > 0)
                {
                    newMinuteValue = (newMinuteValue - (newMinuteValue % $.fn.settings.minute.step)); // set to the previous adjacent step
                }

                if (newHourValue >= ($.fn.settings.hour.max - $.fn.settings.hour.step) &&
                    oldMinuteValue >= ($.fn.settings.minute.max - $.fn.settings.minute.step))
                {
                    newHourValue = $.fn.settings.hour.max - $.fn.settings.hour.step;
                    newMinuteValue = $.fn.settings.minute.max - $.fn.settings.minute.step;
                }
            }

            // change the hour value when the minute value exceed its limits
            if (newMinuteValue >= $.fn.settings.minute.max && newHourValue != $.fn.settings.hour.max && newMinuteValue)
            {
                newMinuteValue = $.fn.settings.minute.min;
                newHourValue = oldHourValue + $.fn.settings.hour.step;
            }
            else if (newMinuteValue < $.fn.settings.minute.min && oldHourValue >= $.fn.settings.hour.step)
            {
                newMinuteValue = $.fn.settings.minute.max - $.fn.settings.minute.step;
                newHourValue = oldHourValue - $.fn.settings.hour.step;
            }
            else if (newMinuteValue < $.fn.settings.minute.min && oldHourValue < $.fn.settings.hour.step)
            {
                newMinuteValue = $.fn.settings.minute.min;
                newHourValue = $.fn.settings.hour.min;
            }

            $($.fn.settings.inputHourTextbox).val(padLeft(newHourValue.toString(), getMaxLength($.fn.settings.hour), $.fn.settings.numberPaddingChar));
            $($.fn.settings.inputMinuteTextbox).val(padLeft(newMinuteValue.toString(), getMaxLength($.fn.settings.minute), $.fn.settings.numberPaddingChar));
            $(container).attr("data-hourvalue", newHourValue);
            $(container).attr("data-minutevalue", newMinuteValue);
            $($.fn.settings.inputMinuteTextbox).trigger("change").select();

            saveOptions(container, $.fn.settings);
        }
    };

    
    function updateTimeValueByArrowKeys(sender, event)
    {
        var container = $(sender).parents(".divTimeSetterContainer");
        loadOptions(container);

        var senderUpBtn = $(container).find("#btnUp");
        var senderDownBtn = $(container).find("#btnDown");
        switch (event.which)
        {
            case 13: // return
                break;

            case 37: // left
                break;

            case 38: // up
                senderUpBtn.click();
                break;

            case 39: // right
                break;

            case 40: // down
                senderDownBtn.click();
                break;

            default: return; // exit this handler for other keys
        }
        event.preventDefault(); // prevent the default action (scroll / move caret)            
        saveOptions(container, $.fn.settings);

        $(sender).select();
    };

    function formatInput(e)
    {
        var element = $(e.target);

        var container = $(element).parents(".divTimeSetterContainer");
        loadOptions(container);

        var unitSettings;

        if (unit === "hours")
        {
            unitSettings = $.fn.settings.hour;
        }
        else if (unit === "minutes")
        {
            unitSettings = $.fn.settings.minute;
        }

        if (!$.isNumeric(element.val()))
        {
            $(element).val(padLeft(unitSettings.min.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }

        var value = parseInt(parseFloat(element.val()));

        // tolerate the wrong step number and move to a valid step
        // ex: user enter 20 while step is 15, auto correct to 15
        if (value >= unitSettings.max)
        {
            value = unitSettings.max - unitSettings.step;
            $(element).val(padLeft(value.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }
        else if (value <= unitSettings.min)
        {
            $(element).val(padLeft(unitSettings.min.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }
        else if (padLeft(value.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar) !== $(element).val())
        {
            $(element).val(padLeft(value.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }
        else if ((value % unitSettings.step) > 0)
        {
            value = (value - (value % unitSettings.step)); // set to the previous adjacent step
            $(element).val(padLeft(value.toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }

        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57))
        {
            //display error message
            return false;
        }

        if (value >= Math.pow(10, getMaxLength(unitSettings)))
        {
            $(element).val(padLeft((Math.pow(10, getMaxLength(unitSettings)) - 1).toString(), getMaxLength(unitSettings), $.fn.settings.numberPaddingChar));
            return false;
        }
    };

    $.fn.getHoursValue = function ()
    {
        var container = $(this).find(".divTimeSetterContainer");
        var txtHour = $(container).find("#txtHours");
        if ($.isNumeric(txtHour.val()))
        {
            return parseInt(txtHour.val());
        }
        return $.fn.settings.hour.min;
    };

    $.fn.getMinutesValue = function ()
    {
        var container = $(this).find(".divTimeSetterContainer");
        var txtMinute = $(container).find("#txtMinutes");
        if ($.isNumeric(txtMinute.val()))
        {
            return parseInt(txtMinute.val());
        }
        return $.fn.settings.minute.min;
    };

    $.fn.getTotalMinutes = function ()
    {
        var container = $(this).find(".divTimeSetterContainer");
        var txtHour = $(container).find("#txtHours");
        var txtMinute = $(container).find("#txtMinutes");

        var hourValue = 0;
        var minuteValue = 0;

        if ($.isNumeric(txtHour.val()) && $.isNumeric(txtMinute.val()))
        {
            hourValue = parseInt(txtHour.val());
            minuteValue = parseInt(txtMinute.val());
        }
        return ((hourValue * 60) + minuteValue);
    };

    $.fn.getPostfixText = function ()
    {
        var container = $(this).find(".divTimeSetterContainer");
        return container.find(".postfix-position").text();
    };

    $.fn.setHour = function (hourValue)
    {
        var container = $(this).find(".divTimeSetterContainer");
        loadOptions(container);

        var txtHours = $(container).find("#txtHours");
        if ($.isNumeric(hourValue))
        {
            txtHours.val(hourValue);
        }
        else
        {
            txtHours.val(padLeft($.fn.settings.hour.min.toString(), getMaxLength($.fn.settings.hour), $.fn.settings.numberPaddingChar));
        }
        unit = "hours"
        saveOptions(container, $.fn.settings);
        txtHours.change();
        return this;
    };

    $.fn.setMinute = function (minuteValue)
    {
        var container = $(this).find(".divTimeSetterContainer");
        loadOptions(container);

        var txtMinute = $(container).find("#txtMinutes");
        if ($.isNumeric(minuteValue))
        {
            txtMinute.val(minuteValue);
        }
        else
        {
            txtMinute.val(padLeft($.fn.settings.minute.min.toString(), getMaxLength($.fn.settings.minute), $.fn.settings.numberPaddingChar));
        }
        unit = "minutes"
        saveOptions(container, $.fn.settings);
        txtMinute.change();
        return this;
    };

    $.fn.setValuesByTotalMinutes = function (totalMinutes)
    {
        var container = $(this).find(".divTimeSetterContainer");
        loadOptions(container);

        var txtHour = $(container).find("#txtHours");
        var txtMinute = $(container).find("#txtMinutes");

        var hourValue = 0;
        var minuteValue = 0;

        // total minutes must be less than total minutes per day
        if (totalMinutes && totalMinutes > 0 && totalMinutes < (24 * 60))
        {
            minuteValue = (totalMinutes % 60);
            hourValue = ((totalMinutes - minuteValue) / 60);
        }

        txtHour.val(padLeft(hourValue.toString(), getMaxLength($.fn.settings.hour), $.fn.settings.numberPaddingChar));
        txtMinute.val(padLeft(minuteValue.toString(), getMaxLength($.fn.settings.minute), $.fn.settings.numberPaddingChar));

        // trigger formattings
        unit = "minutes"
        saveOptions(container, $.fn.settings);
        txtMinute.change(); // one event is enough to do formatting one time for all the input fields
        return this;
    };

    $.fn.setPostfixText = function (textValue)
    {
        var container = $(this).find(".divTimeSetterContainer");
        container.find(".postfix-position").text(textValue);
        return this;
    };

    $.fn.getDefaultSettings = function ()
    {
        return {
            hour: {
                value: 0,
                min: 0,
                max: 24,
                step: 1,
                symbol: "h"
            },
            minute: {
                value: 0,
                min: 0,
                max: 60,
                step: 5,
                symbol: "mins"
            },
            direction: "increment", // increment or decrement
            inputHourTextbox: null, // hour textbox
            inputMinuteTextbox: null, // minutes textbox
            postfixText: "", // text to display after the input fields
            numberPaddingChar: '0' // number left padding character ex: 00052
        };
    };

    /**
     * plugin options for the element
     */
    $.fn.settings = $.fn.getDefaultSettings();

    /**
     * unit is taken out from $.fn.settings to make it globally affect as currently user is concern about which unit to change.
     */
    var unit = "minutes"; /* minutes or hours */

    function getMaxLength(unitSettings)
    {
        return unitSettings.max.toString().length;
    };

    function saveOptions(container, options)
    {
        if (options)
        {
            $.fn.settings = $.extend($.fn.settings, options);
        }
        else
        {
            $.fn.settings = $.fn.getDefaultSettings();
        }
        $(container).data('options', $.fn.settings);
        return $.fn.settings;
    };

    function loadOptions(container)
    {
        var savedOptions = $(container).data('options');
        if (savedOptions)
        {
            $.fn.settings = $.extend($.fn.settings, $(container).data('options'));
        }
        else
        {
            $.fn.settings = $.fn.getDefaultSettings();
        }
        return $.fn.settings;
    }

    /**
     * plugin UI html template
     */
    var htmlTemplate =
	'<div class="form-control divTimeSetterContainer">' +
		'<div class="timeValueBorder">' +
			'<input id="txtHours" type="text" class="timePart hours" data-unit="hours" autocomplete="off" />' +
			'<span class="hourSymbol"></span>' +
			'<span class="timeDelimiter">:</span>' +
			'<input id="txtMinutes" type="text" class="timePart minutes" data-unit="minutes" autocomplete="off" />' +
			'<span class="minuteSymbol"></span>' +
			'<div class="button-time-control">' +
				'<div id="btnUp" type="button" data-direction="increment" class="updownButton" align="center">' +
					'<i class="fa fa-angle-up arrow"></i>' +
				'</div>' +
				'<div id="btnDown" type="button" data-direction="decrement" class="updownButton" align="center">' +
					'<i class="fa fa-angle-down arrow"></i>' +
				'</div>' +
			'</div>' +
		'</div>' +
        '<label class="postfix-position"></label>' +
	'</div>';

}(jQuery));




