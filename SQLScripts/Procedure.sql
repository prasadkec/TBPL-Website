  
CREATE PROCEDURE [dbo].[pDMLContactInsert]  
(  
 
 @JParamVal Nvarchar(Max),  
 @ReturnRIid bigint OUTPUT  
   
)  
As  
BEGIN  
  
  
    SELECT * into #TempRIMaster  
 FROM OPENJSON (@JParamVal, N'$')  
 WITH (  
     Name nvarchar(100) N'$.Name',   
  Email nvarchar(100) N'$.Email',  
  Message nvarchar(100) N'$.Message',  
  Options nvarchar(100) N'$.Option'

 ) AS JsonRIMaster;  
  
    
   
Declare @Code Nvarchar(50)  
    
--EXEC pGenerateCode 'RIMaster',@Code OUTPUT  
  
 INSERT INTO Contact (  Name,Options,Message,Email)
    
 Select   
   Name,Options,Message,Email
 From #TempRIMaster  
  
  Select @ReturnRIid = @@IDENTITY    
 
  
END  
  