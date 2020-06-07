CREATE TABLE [dbo].[employee] (
    [id]         NVARCHAR (128) NOT NULL,
    [name]       NVARCHAR (255) NOT NULL,
    [surname]    NVARCHAR (255) NOT NULL,
    [middlename] NVARCHAR (255) NOT NULL,
    [birth_date] DATETIME       NOT NULL,
    [email]      NVARCHAR (255) NOT NULL,
    [phone]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_dbo.employee] PRIMARY KEY CLUSTERED ([id] ASC)
);

