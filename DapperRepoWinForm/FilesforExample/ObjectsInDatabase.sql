USE [DapperDB]
GO

/****** Object:  Table [dbo].[users]    Script Date: 03/02/2017 10:47:59 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

------
USE [DapperDB]
GO

/****** Object:  StoredProcedure [dbo].[users_DeleteRow_By_id]    Script Date: 03/02/2017 10:48:09 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================
-- Entity Name:	usuario_DeleteRow_By_id
-- Create date:	13/01/2017 03:40:55 p.m.
-- Description:	This stored procedure is intended for deleting a specific row from usuario table
-- ==========================================================================================
CREATE Procedure [dbo].[users_DeleteRow_By_id]
	@id nvarchar(50)
As
Begin
	Delete users
	Where
		[id] = @id

End

GO

-----
USE [DapperDB]
GO

/****** Object:  StoredProcedure [dbo].[users_Insert_Update]    Script Date: 03/02/2017 10:48:32 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ==========================================================================================
-- Entity Name:	users_Insert_Update
-- Create date:	13/01/2017 03:40:55 p.m.
-- Description:	This stored procedure is intended for inserting values to usuario table
-- ==========================================================================================
CREATE Procedure [dbo].[users_Insert_Update]
	@id nvarchar(50),
	@name nvarchar(50),
	@address nvarchar(50),
	@status nvarchar(50)
As
BEGIN
IF NOT EXISTS (SELECT * FROM dbo.users u WHERE u.id = @id)
BEGIN

	Insert Into users
		([id],[name],[address],[status])
	Values
		(@id,@name,@address,@status)
END
ELSE
BEGIN
Update users
	Set
		[id] = @id,
		[name] = @name,
		[address] = @address,
		[status] = @status
	Where		[id] = @id
END
End
GO

-----
USE [DapperDB]
GO

/****** Object:  StoredProcedure [dbo].[users_SelectAll]    Script Date: 03/02/2017 10:48:49 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================
-- Entity Name:	usuario_SelectAll
-- Create date:	13/01/2017 03:40:55 p.m.
-- Description:	This stored procedure is intended for selecting all rows from usuario table
-- ==========================================================================================
CREATE Procedure [dbo].[users_SelectAll]
As
Begin
	SELECT  dbo.users.id
	, dbo.users.name
	, dbo.users.address
	, dbo.users.status FROM dbo.users 
End

GO

-----
USE [DapperDB]
GO

/****** Object:  StoredProcedure [dbo].[users_SelectRow_By_id]    Script Date: 03/02/2017 10:49:00 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================
-- Entity Name:	usuario_SelectRow_By_id
-- Create date:	13/01/2017 03:40:55 p.m.
-- Description:	This stored procedure is intended for selecting a specific row from usuario table
-- ==========================================================================================
CREATE Procedure [dbo].[users_SelectRow_By_id]
	@id nvarchar(50)
As
Begin
	Select  
	dbo.users.id
	, dbo.users.name
	, dbo.users.address
	, dbo.users.status
		
	From users
	Where
[id] = @id
End

GO

-- ==========================================================================================
-- Entity Name:	usuario_SelectAll
-- Create date:	13/01/2017 03:40:55 p.m.
-- Description:	This stored procedure is intended for selecting all rows from usuario table
-- ==========================================================================================
CREATE Procedure [dbo].[users_SelectwithDate]
As
Begin
	SELECT  dbo.users.id
	, dbo.users.name
	, dbo.users.address
	, dbo.users.status 
	, getdate() AS [date]
	FROM dbo.users 
End

GO

