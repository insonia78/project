<html>
    <head>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    </head>
    <script>
    $(document).ready(function(){
        $(".submit").click(function(){
            
        let data = {
            email: $(".email").val(),
            password: $(".password").val()
        };        
        $.post({
            url: "api/login", 
            data , 
            success: (result) => { 
             console.log(result); 
             document.cookie = 'token=' + result.token;      
             $(".result").html("<p>token:"+result.token+"</p>"
                              +"<p>token type:"+result.token_type+"</p>"
                              +"<p>experires in:"+result.expires_in+"</p>");
       },
       error:( error ) =>{
           $(".result").val(error)
        }});
    });
    
});
    </script>    
    <body>
        <fieldset style="width:20%;">
             <legend>Login</legend>
             <label>Email:</label>
             <input style="position:relative;left:10%;" type="email" class="email" value="test@test.com" />
             <br>
             <br>
             <label>Password:</label>
             <input style="position:relative;left:2%;" type="password" class="password" value="test"/>
             <br>
             <br>
             <input type="button" value="submit" class="submit"/>             
        </fieldset>
        <div class="result"></div>        
    </body>
</html>