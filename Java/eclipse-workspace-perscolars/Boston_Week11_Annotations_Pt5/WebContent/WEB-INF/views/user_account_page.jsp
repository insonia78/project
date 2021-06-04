<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>User Account Page</title>
</head>
<body>
	<h1>User Account Page</h1>
	<div>
		<table>
			<tr>
				<td>User Name</td>
				<td>${newUser.username}</td>
			</tr>
			<tr>
				<td>Password</td>
				<td>${newUser.password}</td>
			</tr>
			<tr>
				<td>User Name</td>
				<td>${newUser.email}</td>
			</tr>
		</table>
	</div>
</body>
</html>