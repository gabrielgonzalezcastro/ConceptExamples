setTimeout(function() {
    loaded = true; 
    $.holdReady(false); // release the execution of the ready event
},3000)