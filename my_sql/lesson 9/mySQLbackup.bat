REM mySQLbackup.bat first parameter is the database name
REM * backup the mySQL database, username is backupUser
REM *
REM * The PATH is the location of the mySQL utility programs, mysqldump in this case.
PATH ;
PATH C:\xampp\mysql\bin
REM
REM below the filename will be in the format backupYYYYMMDD, every file will be unique
mysqldump --user=backupUser --password=bkpUser123#@! --resultfile="c:\usr\local\Backups\MybackupMysql%DATE:~10,4%%DATE:~4,2%%DATE:~7,2%.sql"%1
REM *
REM modify this .bat file if you prefer the file name to be in the format
backupWEEKDAY.sql, like backupTHU.sql
REM It works great for weekly backups, overwriting each day as the backups run
REM mysqldump --user=backupUser --password=bkpUser123#@! --resultfile="c:\usr\local\Backups\MybackupMysql%DATE:~0,3%.sql"
%1
REM * 