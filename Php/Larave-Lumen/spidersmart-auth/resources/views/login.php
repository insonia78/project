<html>
    <head>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    </head>
    <script>
    $(document).ready(function(){
        $(".submit").click(function(){
            
        let data = {
            "grant_type":"password",
            "client_id":"2",
            "client_secret":"NUZjJNW6aqExuI3u4CbwSJEugndM4Wd3tLHiG8ty",
            "username": $.trim($(".username").val()),
            "password": $.trim($(".password").val().trim()),
            "scope":"*"

        };
        console.log(data);        
        $.post({
            url: "oauth/token", 
            data , 
            success: (result) => {                          
             document.cookie = result.access_token;             
             $(".result").html("<p>token:"+result.access_token+"</p>"
                              +"<p>token type:"+result.token_type+"</p>"
                              +"<p>experires in:"+result.expires_in+"</p>");
       },
       error:( error ) =>{
           console.log(error);
           $(".result").val(error)
        }});
    });
    
});
    </script>    
    <body>
        <fieldset style="width:20%;">
             <legend>Login</legend>
             <label>Username:</label>
             <input style="position:relative;left:10%;" type="text" class="username" value="test" required/>
             <br>
             <br>
             <label>Password:</label>
             <input style="position:relative;left:2%;" type="password" class="password" value="test" required/>
             <br>
             <br>
             <input type="submit" value="submit" class="submit"/>             
        </fieldset>
        <div class="result"></div>        
    </body>
</html>