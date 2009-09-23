/* Creates initial tables for Projects, ProjectCategories, ProjectImages */

if not exists (select * from dbo.sysobjects where id = object_id(N'Projects') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
create table Projects (
   Id INT IDENTITY NOT NULL,
   Name NVARCHAR(25) not null,
   Description NVARCHAR(255) not null,
   CategoryId INT not null,
   Thumbnail INT null,
   Image INT null,
   primary key (Id)
)
END
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'ProjectCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
create table ProjectCategories (
    Id INT IDENTITY NOT NULL,
   Name NVARCHAR(15) not null,
   primary key (Id)
)
END
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'ProjectImages') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
create table ProjectImages (
    Id INT IDENTITY NOT NULL,
   Data IMAGE not null,
   primary key (Id)
)
END
GO

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Project_ProjectCategory]') AND parent_object_id = OBJECT_ID('Projects'))
BEGIN
alter table Projects 
    add constraint FK_Project_ProjectCategory 
    foreign key (CategoryId) 
    references ProjectCategories
END
GO

if not exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Project_ThumbnailImage]') AND parent_object_id = OBJECT_ID('Projects'))
BEGIN
alter table Projects 
    add constraint FK_Project_ThumbnailImage 
    foreign key (Thumbnail) 
    references ProjectImages
END
GO

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Project_Image]') AND parent_object_id = OBJECT_ID('Projects'))
BEGIN
alter table Projects 
    add constraint FK_Project_Image 
    foreign key (Image) 
    references ProjectImages
END
GO
