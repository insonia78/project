//The pourpese of this class is to model a television
// Thomas Zangari
public class Television
{
	private final String MANUFACTURER;
	private final int SCREEN_SIZE;
	boolean powerOn = false;
	int channel = 999 ;
	int volume = 20;

	public Television(String brand,int size)
    {
		 MANUFACTURER = brand ;
		 SCREEN_SIZE = size ;
	}
	public void setChannel(int station)
	{
		channel = station;
	}
	public  void power()
	{
		powerOn = !powerOn;
	}
	public void increaseVolume()
	{
	  volume++;
    }
    public void decreaseVolume()
    {
		volume--;
	}
	public int getChannel()
	{
		if (channel >= 1 && channel <=999)
		{
		return channel ;
		}
		else
		{
		   System.out.println("invalid channel: " + channel);
		   return channel ;
		}
	}
    public int getVolume()
    {
		if (volume == 20)
		{
          System.out.println("Volume at max; can't be turned up further");
		  return volume;
	    }
	    else
	    {
		 return volume;
		}
	}
	public String getManufacturer()
	{
		return MANUFACTURER;
	}
	public int getScreenSize()
	{
		return SCREEN_SIZE;
	}

}