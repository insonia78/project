<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login</title>
</head>
<body>
	<h1>Login Form</h1>
	<form action="login" method="POST">
		<div>
			<label>Email: </label>
			<input type="text" name="email" />
		</div>
		<div>
			<label>Password: </label>
			<input type="password" name="password" />
		</div>
		<div>
			<input type="submit" value="Login" />
		</div>
	</form>
</body>
</html>