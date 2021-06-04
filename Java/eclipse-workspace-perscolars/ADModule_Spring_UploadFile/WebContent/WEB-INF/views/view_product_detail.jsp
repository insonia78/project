<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix = "c" uri = "http://java.sun.com/jsp/jstl/core" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>View Product Detail</title>
</head>
<body>
	<div>
		<h4>The product has been saved.</h4>
		<h5>Details:</h5>
		<p>Product Name: ${product.name}</p>
		<p>Description: ${product.description}</p>
		<p>The following files are uploaded successfully.</p>
		<ol>
			<c:forEach items="${product.images}" var="image">
				<li><p>${image.originalFilename}</p><img src="<c:url value="/resources/images/${image.originalFilename}" />" /></li>
			</c:forEach>
		</ol>
	</div>
</body>
</html>