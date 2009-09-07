
    drop table if exists Projects

    drop table if exists ProjectCategories

    drop table if exists ProjectImages

    create table Projects (
        Id  integer,
       Name TEXT not null,
       Description TEXT not null,
       CategoryId INTEGER not null,
       primary key (Id)
    )

    create table ProjectCategories (
        Id  integer,
       Name TEXT not null,
       primary key (Id)
    )

    create table ProjectImages (
        Id  integer,
       Thumbnail BLOB not null,
       FullSize BLOB not null,
       ProjectId INTEGER not null,
       primary key (Id)
    )
