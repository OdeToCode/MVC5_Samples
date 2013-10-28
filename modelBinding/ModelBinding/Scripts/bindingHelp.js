(function($) {

    $.showRequest = function(data) {
        var $request = $("#request");        
        $request.text(JSON.stringify(data, null, 2));
    };

    $.showResponse = function(data) {
        var $response = $("#response");
        $response.text(JSON.stringify(data, null, 2));
    };

}(jQuery));