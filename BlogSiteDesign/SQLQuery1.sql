--Create Trigger AddBlogInRayting
--on Blogs
--After Insert
--as
--declare @ID int
--Select @ID=BlogID from inserted 
--insert into BlogRaytings(BlogID,BlogTotalScore,BlogRaytingCount) values (@ID,0,0)

Create Trigger AddScoreInComment
On Comments
after Insert
as
declare @ID int
declare @Score int
declare @RaytingCount int
Select @ID=BlogID,@Score=BlogScore from inserted
update BlogRaytings set BlogTotalScore=BlogTotalScore+@Score, BlogRaytingCount+=1
where BlogID=@ID