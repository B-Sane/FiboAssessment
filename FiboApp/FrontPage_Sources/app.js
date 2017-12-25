$(document).ready(function(){
    //handling css when focused or not in a field
	$('.field-input').focus(function(){
		$(this).parent().addClass('is-focused is-labeled');
	})

	$('.field-input').blur(function(){
		$parent = $(this).parent();

		if($(this).val() == null){
			$parent.removeClass('is-labeled');
		}
		
		$parent.removeClass('is-focused');
	})


	var port = "54902";
	var apiUrl = "http://localhost:"+port+"/api/itg/v1/fibonacci/sequence";
	
	//Format data from form into json
	var form = document.querySelector("form");
	    // Gestion de la soumission du formulaire
	form.addEventListener("submit", function (e) {
	    e.preventDefault();

	    var dataToSend = JSON.stringify({
	        "start": $('#start').val(),
	        "end": $('#end').val()
	    });
        
	    //Sending the form to the api
	    ajaxPost(apiUrl, dataToSend);
	});

    
	function ajaxPost(url, data) {
	    var req = new XMLHttpRequest();
	    req.open("POST", url);
	    req.onreadystatechange = function () {
	        if (req.readyState === XMLHttpRequest.DONE && (req.status === 200 || req.status === 0)) {
	            $('.form').hide();
	            //Insert API response in the page
	            var resp = JSON.parse(req.responseText);
	            $('#result').html("<p>Here is the Result with [" + $('#start').val()+ "-" + $('#end').val()+"] as boundaries  : <p><br>" + resp);

	            //Add a link for trying again
	            $('#try-again').html("<a href=\"index.html\">try again</a>")
                
	        } else {
	            console.error(req.status + " " + req.statusText + " " + url);
	        }
	    };
        
	    req.setRequestHeader("Content-type", "application/json; charset=utf-8");
	    req.send(data);
	}

})