<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Product Form</title>
</head>
<body>
	<form:form modelAttribute="product" action="saveProduct" method="post"
		enctype="multipart/form-data">
		<fieldset>
			<legend>Add a Product</legend>
			<div>
				<label for="name">Product Name: </label>
				<form:input id="name" path="name" />
				<form:errors path="name"></form:errors>
			</div>
			<div>
				<label for="description">Description: </label>
				<form:input id="description" path="description" />
				<form:errors path="description"></form:errors>
			</div>
			<div>
				<label for="image">Product Images: </label>
				<input type="file" name="images" multiple="multiple" />
			</div>
			<div>
				<input id="reset" type="reset" tabindex="4"/>
				<input id="submit" type="submit" tabindex="5" value="Add Product" />
			</div>
		</fieldset>
	</form:form>
</body>
</html>