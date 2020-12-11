IF DB_ID('YouTubeApp') IS NULL
CREATE DATABASE YouTubeApp
GO
USE YouTubeApp;
drop table if exists tblSubscribers
drop table if exists tblCommentLikes
drop table if exists tblVideoLikes 
drop table if exists tblComment 
drop table if exists tblVideo
drop table if exists tblUser

create table tblUser(
   Id          int            identity (1,1) primary key,   
   Username    nvarchar(100)    unique   not null,
   Email       nvarchar(100)    unique   not null,
   Password    nvarchar(max)             not null, 
   IsDeleted   bit			   default 0 not null,
)

create table tblVideo(
   Id                 int          identity (1,1) primary key,   
   VideoName          nvarchar(100)          not null,
   VideoViews         int          default 0 not null,
   VideoPath          nvarchar(max)          not null,
   Description        nvarchar(max)          not null,  
   UserId             int                    not null,
   FOREIGN KEY (UserId) REFERENCES tblUser(Id),
   IsDeleted       bit			   default 0 not null,
)

create table tblVideoLikes(
   Id                  int          identity (1,1) primary key, 
   VideoId             int                    not null,
   FOREIGN KEY (VideoId) REFERENCES tblVideo(Id),
   UserId              int                    not null,
   FOREIGN KEY (UserId) REFERENCES tblUser(Id),
   IsLiked            bit				     not null,
   IsDeleted          bit		  default 0 not null,
)

create table tblComment(
   Id                int          identity (1,1) primary key,   
   Content           nvarchar(100)          not null,
   CreateDate        date         default getDate() not null,   
   UserId            int                    not null,
   FOREIGN KEY (UserId) REFERENCES tblUser(Id),
   VideoId           int                    not null,
   FOREIGN KEY (VideoId) REFERENCES tblVideo(Id),
   ParentComment     int                    null ,
   IsDeleted         bit	      default 0 not null,
)

create table tblCommentLikes(
   Id                 int          identity (1,1) primary key, 
   CommentId          int                    not null,
   FOREIGN KEY (CommentId) REFERENCES tblComment(Id),
   UserId             int                    not null,
   FOREIGN KEY (UserId) REFERENCES tblUser(Id),
   IsLiked        bit				     not null,
   IsDeleted       bit			   default 0 not null,
)

create table tblSubscribers(
   Id                 int          identity (1,1) primary key,     
   UserId             int                    not null,
   FOREIGN KEY (UserId) REFERENCES tblUser(Id),
   SubscriberId             int                    not null,
   FOREIGN KEY (SubscriberId) REFERENCES tblUser(Id),
   IsDeleted       bit			   default 0 not null,
)

insert into tblUser(Username, Email, Password)
values('mara', 'mara@gmail.com', 'marija'),
	  ('mirko', 'mirko@gmail.com', 'marija')

insert into tblVideo(VideoName, VideoPath, Description, UserId)
values('NekaPesma', 'C:\Users\praksa.1\Desktop\YouTube\Server\Server\Resource\Video\VID_20201014_174748.mp4', 'Neki opis', 1)

insert into tblComment(Content, UserId, VideoId)
values ('comentar na neku pesmu', 1, 1),
	   ('comentar Istu pemsu pesmu', 1, 1)


