create table Contact(
  Id int identity(1,1) primary key, 
  Name nvarchar(100) ,
  Options nvarchar(100) ,
  Message nvarchar(100) ,
  Email nvarchar(100) 
  )