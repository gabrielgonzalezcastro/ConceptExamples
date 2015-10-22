'use strict';

eventsApp.filter('durations', function() {
    return function(duration, language) {

        if (language == 'spanish') {
            switch (duration) {
            case 1:
                return "Media Hora";
            case 2:
                return "1 Hora";
            case 3:
                return "Medio Dia";
            case 4:
                return "Todo El Dia";
            }
        } else {
            switch (duration) {
                case 1:
                    return "Half Hour";
                case 2:
                    return "1 Hour";
                case 3:
                    return "Half Day";
                case 4:
                    return "Full Day";
            }
        }
    }
});

