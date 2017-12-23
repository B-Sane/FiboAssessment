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

	//Sending the form to the API
	$('.button').click('submit', function(e){

	var port = "54902";
	var apiUrl = "http://localhost:"+port+"/api/itg/v1/fibonacci";
	
	//Format data from form into json
	var dataToSend = JSON.stringify(
									{"Start" : $('#Start').val(), 
									"End": $('#End').val()}
									);
	var dto = $('form.formulaire').serialize();
	var dataToSend2 = {"Start" : $('#Start').val(),"End": $('#End').val()};
		

		  var sendTheRequest = function(webAppUrl)
		  {
		  	return new Promise(function(resolve, reject){
		  		
		  		var xhr = new window.XMLHttpRequest()
		  		xhr.onreadystatechange = function(){
			  	if(xhr.readyState === 4 && xhr.status === 200){
			  		resolve(xhr.responseText)
			  	}
			  	else{
			  		reject(xhr)
			  	}
			  	}
			  	xhr.open('POST',webAppUrl, true)
			  	debugger;
			  	xhr.send(dataToSend2);
			
		  	})
		  }

		  var catchError = function(e){
		  	debugger;
		  	console.error('Ajax Error', e)
		  }


		  sendTheRequest(apiUrl).then(function(response){
		  		var resp = JSON.parse(response)
		  		 $('#result').html("<p>Result : <p><br>"+resp);			
		  		console.log(resp)
		  }).catch(catchError)

	})

})