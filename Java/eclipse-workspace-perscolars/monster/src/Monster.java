
public class Monster {
    private String name = "WELCOME";
	public Monster(String name) {
		//this.name = name;
	}
	public String attack() {return "";}
}


class FireMonster extends Monster{
	String name = "Hey";
	public FireMonster(String name)
	{
		super(name);
		this.name = name;
		
	}
	public String attack(){
		return "Attach with fire";
	}
}

class WaterMonster extends Monster{
	public WaterMonster(String name)
	{
		super(name);
	}
	public String attack() {
		return "Attach with water";
	}
	
}

class StoneMonster extends Monster{
	public StoneMonster(String name)
	{
		super(name);
	}
	public String attack() {
		return "Attach with stones";
	}
}

