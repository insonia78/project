package monday.oop2.one;

public class StudentMain {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		AbstractStudent student = new Student();

		student.setFirstName("Jafer");
		student.setLastName("Alhaboubi");
		student.setGPA(4.0);
		student.getInfo();

		String[] name = student.getName();
		for (String i : name) {
			System.out.println();
			System.out.println(i);
			System.out.println();
		}

		StudentI student2 = new Student();
		student2.setNickName("Jay");
		student2.introduceSelf();

	}

}
