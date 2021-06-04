<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Confirm</title>
</head>
<body>
	<h1>Confirm Your Info</h1>
	<form action="userInfoConfirm" method="POST">
		<div>
			<label>User Name: </label> <input type="text" id="user"
				name="username" value="${newUser.username}" />
		</div>
		<div>
			<label>Password: </label> <input type="text" id="pass"
				name="password" value="${newUser.password}" />
		</div>
		<div>
			<label>Email: </label> <input type="text" id="email" name="email"
				value="${newUser.email}" />
		</div>
		<div>
			<label>Date of Birth: </label> <input type="text" id="dob"
				name="dob" value="${newUser.dob}" />
		</div>
		<div>
			<input type="submit" name="submit" value="Submit Info" />
		</div>
	</form>
</body>
</html>