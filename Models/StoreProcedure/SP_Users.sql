CREATE PROCEDURE [dbo].[SP_Users] @ExecuteType VARCHAR(10) = NULL
	,@UserId VARCHAR(10) = NULL
	,@UserName NVARCHAR(20) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	IF @ExecuteType = 'SELECT'
	BEGIN
		SELECT usr.UserId
			,usr.UserName
		FROM Users usr
		WHERE usr.UserId = ISNULL(@UserId, usr.UserId)
		ORDER BY usr.UserId;
	END
	ELSE IF @ExecuteType = 'UPDATE'
	BEGIN
		UPDATE Users
		SET UserName = @UserName
		WHERE UserId = @UserId;

		SELECT usr.UserId
			,usr.UserName
		FROM Users usr
		WHERE UserId = @UserId;
	END
	ELSE IF @ExecuteType = 'INSERT'
	BEGIN
		INSERT INTO Users (
			UserId
			,UserName
			)
		VALUES (
			@UserId
			,@UserName
			);

		SELECT usr.UserId
			,usr.UserName
		FROM Users usr
		WHERE UserId = @UserId;
	END
	ELSE IF @ExecuteType = 'DELETE'
	BEGIN
		DELETE Users
		WHERE UserId = @UserId;
	END
END
/*
CREATE TABLE Users (
	UserId VARCHAR(10) NOT NULL PRIMARY KEY
	,UserName NVARCHAR(20) NOT NULL DEFAULT('')
	)
*/