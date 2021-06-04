<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login Page</title>
</head>
<body>
	<h1>Login Page</h1>
	<p>${SPRING_SECURITY_LAST_EXCEPTION.message}</p>
	<form action="login" method="post">
		<div>
			<label>Username:</label> <input type="text" name="username">
		</div>
		<div>
			<label>Password:</label> <input type="text" name="password">
		</div>
		<div>
			<input type="submit" value="Submit" />
		</div>
	</form>
</body>
</html>