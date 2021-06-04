package org.perscholas.springbootsoapexample.endpoint;

import org.perscholas.springbootsoapexample.GetStudentRequest;
import org.perscholas.springbootsoapexample.GetStudentResponse;
import org.perscholas.springbootsoapexample.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class StudentEndpoint {
	
	
	@Autowired
    private StudentService studentService;


    @PayloadRoot(namespace = "http://perscholas.org/springbootsoapexample",
            localPart = "getStudentRequest")
    
    @ResponsePayload
    public GetStudentResponse getUserRequest(@RequestPayload GetStudentRequest request) {
    	GetStudentResponse response = new GetStudentResponse();
        response.setStudent(studentService.getStudents(request.getName())); //studentService can contain the database query result
        //we want to update the response with a result coming from the query 
        // request.getName() = "Peter"
        // studentService will provide the Student
        
        return response;
    }

}
