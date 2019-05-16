export class CounterService {
activeToInactiveUser:number = 0;
inactiveToActiveUser:number = 0;

incrementActivetoInactive()
{
    this.activeToInactiveUser++;
    console.log(this.activeToInactiveUser);
}
incrementInactivetoActive()
{
    this.inactiveToActiveUser++;
    console.log(this.inactiveToActiveUser);
}
}