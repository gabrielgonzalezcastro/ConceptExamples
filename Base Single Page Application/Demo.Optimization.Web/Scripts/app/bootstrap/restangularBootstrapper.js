(function(ng, window) {
    var app = angular.module('app.bootstrap', []);

    function provider() {
        this.$get = [
            'RestangularProvider', function() {
                return {};
            }
        ];

        this.configure = function(restangularProvider) {
            restangularProvider.setBaseUrl('/public/api/v1');
            restangularProvider.setDefaultHeaders({ AuthToken: window.appConfig.token });

            var currentCalls = 0;

            function decrementCurrentCalls() {
                currentCalls--;
                if (currentCalls === 0) {
                    window.appConfig.rootScope.$broadcast('Restangular_HideLoading');
                }
            }

            //Add an interceptor for each response from the server
            //data - data retreived from the server
            //operation - the HTTP method used
            //what - the model that's requested
            //url - the relative URL that is being requested
            //response - the full server response, including headers,
            //deferred - the promise for the request
            restangularProvider.addResponseInterceptor(function(data, operation, what, url, response, deferred) {
                if (response.headers("AuthToken")) {
                    window.appConfig.token = response.headers("AuthToken");
                    restangularProvider.setDefaultHeaders({ AuthToken: window.appConfig.token });
                }

                decrementCurrentCalls();
                if (operation === "getList" && !data) {
                    data = [];
                }
                return data;
            });

            //Prepare the request before to be sent to the API
            //element - the element we are sending to the server
            //operation - the HTTP method used
            //what - the model that's being requested
            //url - the relative URL that is being requested
            restangularProvider.addFullRequestInterceptor(function(elem, operation, what, url, headers, params, httpConfig) {
                currentCalls++;
                window.appConfig.rootScope.$broadcast('Restangular_ShowLoading');
            });

            //Error Interceptors
            restangularProvider.setErrorInterceptor(function(response, deferred, responseHandler) {
                function parseMessageException(message) {
                    message = message.split(":<hr>\r\n").join(":<hr>");
                    return window.appConfig.sanitize(message.split("\r\n").join("<br/>"));
                }

                decrementCurrentCalls();

                //Server error - not captured on .NET
                if (response.status === 500) {
                    deferred.reject(response);

                    if (respose.data.exceptionMessage === "Invalid Token") {
                        window.appConfig.rootScope.$broadcast('Restangular_TokenExpired', { title: response.data.message, message: response.data.exceptionMessage });
                    } else {
                        window.appConfig.rootScope.$broadcast('Restangular_ServerError', { title: response.data.message, message: response.data.exceptionMessage });
                        console.debug(JSON.stringify(response.data));
                    }

                    //Handled error
                    return true;
                }

                //Bad request - validations, wrong params
                if (response.status === 400) {
                    deferred.reject(response);

                    if (response.data && response.data.ClassName === 'Base.Core.Exception.CommandException') {
                        window.appConfig.rootScope.$broadcast('Restangular_BadRequest', { title: 'Validation errors found', message: parseMessageException(response.data.Message) });
                        return true;
                    }

                    //Handled error
                    return false;
                }

                //Error not handled
                return true;

            }); //end setErrorInterceptor

        }; //end configure

    } //end function provider

    app.provider('restangularBootstrapper', provider);
})(angular, window);