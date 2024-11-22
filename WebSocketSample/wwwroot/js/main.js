'use strict';

$(document).ready(function () {
    console.log("Ready");
    var obj = document;
     

    
});
(function () {



    // Parse the configuration data for WebSocket from server-side model
    var parseModel = JSON.parse(communicationInfo.toLowerCase());

    var PortNo = parseModel.portno;

    var Ip = parseModel.url;

    var url = 'ws://' + Ip+':' + PortNo +'/';

    var ws = new RobustWebSocket(url); // Initialize WebSocket with robust connection handling

    // Listen for messages received from the WebSocket server
    ws.addEventListener('message', function (event) {        
        // Append incoming data to textAcknowledge
        $('#textAcknowledge').val(function (index, oldValue) {
            return oldValue + '\n' + event.data;
        });
    });
    

    // Form submission handler for sending data through WebSocket
    $('#myForm').submit(function (event) {
        event.preventDefault(); // Prevent normal form submission

        // Prepare command text from textCommand, replacing newlines for Windows compatibility
        var textValue = $('#textCommand').val().replace(/\n/g, "\r\n");
        console.log("textsvad");
        console.log(textValue);

        // Check if WebSocket is open before sending data
        if (textValue && ws.readyState === WebSocket.OPEN)
        {
            
            ws.send(textValue);
            
        } else {
            // Reinitialize WebSocket if connection is not open
            ws = new RobustWebSocket(url);
            ws.send(textValue);// Send command after re-establishing connection
           
        }
    });

    

})();
