IF DB_ID('BetweenUsDb') IS NULL
CREATE DATABASE BetweenUsDb
GO

USE BetweenUsDb
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblFriendRequests')
DROP TABLE tblFriendRequests
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblUsersThatLikedPost')
DROP TABLE tblUsersThatLikedPost
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblUsers')
DROP TABLE tblUsers
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblPosts')
DROP TABLE tblPosts

CREATE TABLE tblUsers(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(30),
Surname varchar(50),
DateOfBirth date,
Gender varchar(10),
Username varchar(30),
Password varchar(30)
);

CREATE TABLE tblFriendRequests(
Id int PRIMARY KEY IDENTITY(1,1),
DateOfCreating DateTime,
Accepted bit,
FKRequestSender int,
FKRequestReceiver int
);

CREATE TABLE tblPosts(
Id int PRIMARY KEY IDENTITY(1,1),
DateTimeOfPosting DateTime,
Content varchar(100),
NumberOfLikes int,
FKUserThatPosted int
);

CREATE TABLE tblUsersThatLikedPost(
Id int PRIMARY KEY IDENTITY(1,1),
FKPost int,
FKUser int
);

ALTER TABLE tblFriendRequests ADD FOREIGN KEY(FKRequestSender) REFERENCES tblUsers(Id);
ALTER TABLE tblFriendRequests ADD FOREIGN KEY(FKRequestReceiver) REFERENCES tblUsers(Id);
ALTER TABLE tblPosts ADD FOREIGN KEY(FKUserThatPosted) REFERENCES tblPosts(Id);
ALTER TABLE tblUsersThatLikedPost ADD FOREIGN KEY(FKPost) REFERENCES tblPosts(Id);
ALTER TABLE tblUsersThatLikedPost ADD FOREIGN KEY(FKUser) REFERENCES tblUsers(Id);
