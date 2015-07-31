drop table if exists apothegm;
create table apothegm (attribution varchar(40),phrase text)engine = MyISAM;
load data local infile 'apothegm.txt' into table apothegm;
alter table apothegm 
      add fulltext (phrase),
      add fulltext (attribution),
      add fulltext  (phrase,attribution);
