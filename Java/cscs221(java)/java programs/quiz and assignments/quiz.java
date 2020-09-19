import java.util.Scanner;
public class quiz
{
	public static void https://blackboard.ccri.edu/courses/1/22068.201320/ppg/respondus/pool_ScopeDuration_Gaddis/scope1ag.pngmain(String[] args)
	{
		Scanner keyboard = new Scanner(System.in);
		int studentGrade = 0;
		int totalOfStudentGrades = 0;
		while (studentGrade != -1)
		{
		    System.out.println("Enter student grade: ");
		    studentGrade = keyboard.nextInt();
		    totalOfStudentGrades += studentGrade;

        }
	System.out.print(totalOfStudentGrades );
	}
}
