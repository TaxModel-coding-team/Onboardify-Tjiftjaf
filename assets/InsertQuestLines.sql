DECLARE @QuestID1 AS uniqueidentifier = NEWID();
DECLARE @QuestID2 AS uniqueidentifier = NEWID();

INSERT INTO [dbo].[Quest]
           ([ID]
           ,[Title]
           ,[Description])
     VALUES
           (
			   @QuestID1,
			   'Colleagues',
			   'The friends we make along the way'
		   ),
		   (
			   @QuestID2,
			   'Coffee',
			   'The way of the coffee'
		   )
INSERT INTO [dbo].[SubQuest]
	VALUES
		(
			NEWID(), 
			'Talk with Jimmy', 
			10, 
			@QuestID1
		),
		(
			NEWID(), 
			'Talk with Bob', 
			15, 
			@QuestID1
		),
		(
			NEWID(), 
			'Talk with Ronald', 
			20, 
			@QuestID1
		),
		(
			NEWID(), 
			'Locate the coffee machine', 
			10, 
			@QuestID2
		),
		(
			NEWID(), 
			'Set your first cup of coffee', 
			15, 
			@QuestID2
		)