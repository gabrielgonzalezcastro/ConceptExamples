'use strict';

eventsApp.directive('gravatar', function (gravatarUrlBuilder) {
    return {
        restrict: 'E',
        template: '<img />', //template of the directive
        replace: true,
        link: function (scope, element, attrs, controller) {
            attrs.$observe('email', function (newValue, oldValue) { // observe when the email attribute change
                if (newValue !== oldValue) {
                    attrs.$set('src', gravatarUrlBuilder.buildGravatarUrl(newValue)); // set a new attribute ('src') to the img tag
                }
            });
        }

    }
});
