package tuesday.fundamentalclauses;

import java.util.ArrayList;
import java.util.List;

public class Game {
	private List<Player> players;

	public Game()
	{
		this.players = new ArrayList<>();
	}
	
	public List<Player> getPlayers() {
		return players;
	}

	public void setPlayers(List<Player> players) {
		this.players = players;
	}
}