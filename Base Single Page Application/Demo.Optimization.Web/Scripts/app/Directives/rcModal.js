(function(ng, $) {

    function directiveFactory($compile) {

        function createModalContainer(el) {
            var modalContainer = $('<div id="container-' + $(el).attr('id') + '" class="rc-modal-container"><div/>');
            $('body').prepend(modalContainer);

            return modalContainer;
        }

        function createModalWrapper(el) {
            var modalWrapper = $('<div class="rc-modal-wrapper"></div>');
            $(el).wrap(modalWrapper);
            modalWrapper = $(el).closest(".rc-modal-wrapper");

            return modalWrapper;
        }

        return {
            restrict: 'A',
            link: function(scope, el, attrs, ctrl) {
                var modalContainer = createModalContainer(el);
                var modalWrapper = createModalWrapper(el);

                function show() {
                    modalContainer.addClass('shown');
                    modalWrapper.fadeIn(200, function() {
                        modalWrapper.addClass('shown');
                    });
                }

                function hide() {
                    modalWrapper.fadeOut(200, function() {
                        modalContainer.removeClass('shown');
                        modalWrapper.removeClass('shown');
                    });
                }

                function setWidth() {
                    if (attrs.rcModalWidth == null) {
                        attrs.rcModalWidth = 600;
                    }

                    //Set the popup maximum size to the window size;
                    var windowsWidth = window.innerWidth;
                    if (attrs.rcModalWidth > windowsWidth) {
                        attrs.rcModalWidth = windowsWidth;
                    }

                    modalWrapper.css('width', attrs.rcModalWidth);
                    modalWrapper.css('margin-left', -1 * (attrs.rcModalWidth / 2));
                }

                function initialise() {
                    //Set config options
                    if (attrs.rcModalUrl) {
                        $(el).load(attrs.rcModalUrl + '?v=' + window.appConfig.applicationVersion, function() {
                            $compile(el.contents())(scope);
                            scope.$apply();
                        });
                    }

                    if (attrs.rcModalTitle) {
                        modalWrapper.prepend('<span class="title">' + attrs.rcModalTitle + '</span>');
                    }

                    if (attrs.rcModalHeight) {
                        modalWrapper.css('height', attrs.rcModalHeight);
                        el.css('height', attrs.rcModalHeight - 120);
                    }

                    setWidth();

                    //Add styles
                    el.addClass("rc-modal");

                    //Set bindings
                    el.on('show', function() {
                        show();
                    });

                    el.on('hide', function() {
                        hide();
                    });

                    $('.close', modalWrapper).on('click', function() {
                        hide();
                    });

                    $('.modal-close', modalWrapper).on('click', function() {
                        hide();
                    });

                    //Initialise Control
                    initialise();

                }

            } //end link
        }; //end return

    } //end directiveFactory

    angular.module('BookApp').directive('rcModal',['$compile', directiveFactory]);

})(angular, window.jQuery);