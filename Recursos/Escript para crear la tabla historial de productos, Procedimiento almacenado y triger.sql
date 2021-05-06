USE [MiniMarketDev]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--Autor					: ING. LENIN ORMAZA ALVAREZ
--Fecha de Creaión		: 06/05/2021
-- =============================================
CREATE TABLE [dbo].[ProductHistory](
	[Fecha] [date] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DescriptionOld] [nvarchar](500) NOT NULL,
	[DescriptionNew] [nvarchar](500) NOT NULL,
	[CategoryIdOld] [smallint] NOT NULL,
	[CategoryIdNew] [smallint] NOT NULL,
	[SupplierIdOld] [smallint] NOT NULL,
	[SupplierIdNew] [smallint] NOT NULL,
	[BrandOld] [nvarchar](50) NOT NULL,
	[BrandNew] [nvarchar](50) NOT NULL,
	[ModelOld] [nvarchar](50) NOT NULL,
	[ModelNew] [nvarchar](50) NOT NULL,
	[MeasureOld] [nvarchar](50) NOT NULL,
	[MeasureNew] [nvarchar](50) NOT NULL,
	[PriceOld] [decimal](10, 2) NOT NULL,
	[PriceNew] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[Get_Products]
	@ID AS INT,
	@Page AS INT = NULL,
	@Take AS INT = NULL
AS
BEGIN
	IF @ID IS NULL BEGIN
		SELECT DISTINCT * FROM [dbo].[Products] AS P
		ORDER BY P.[Brand], P.[Model] ASC 
		OFFSET (@Page - 1)*@Take ROWS
		FETCH NEXT @Take ROWS ONLY;
	
	END ELSE BEGIN
		SELECT DISTINCT * FROM [dbo].[Products] AS P
		WHERE (P.[ProductId] = @ID)
		ORDER BY P.[Brand], P.[Model] ASC 
	END
END
GO

CREATE TRIGGER [dbo].[TR_ProductUpdate] ON [dbo].[Products] FOR UPDATE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @ProductId AS INT
	DECLARE @DescriptionOld AS NVARCHAR(500)
	DECLARE @CategoryIdOld AS SMALLINT
	DECLARE @SupplierIdOld AS SMALLINT
	DECLARE @BrandOld AS NVARCHAR(50)
	DECLARE @ModelOld AS NVARCHAR(50)
	DECLARE @MeasureOld AS NVARCHAR(50)
	DECLARE @PriceOld AS DECIMAL(10, 2)
	SELECT @ProductId = D.[ProductId], @DescriptionOld = D.[Description], @CategoryIdOld = D.[CategoryId], @SupplierIdOld = D.[SupplierId],
			@BrandOld = D.[Brand], @ModelOld = D.[Model], @MeasureOld = D.[Measure], @PriceOld = D.[Price] FROM deleted AS D
	DECLARE @DescriptionNew AS NVARCHAR(500)
	DECLARE @CategoryIdNew AS SMALLINT
	DECLARE @SupplierIdNew AS SMALLINT
	DECLARE @BrandNew AS NVARCHAR(50)
	DECLARE @ModelNew AS NVARCHAR(50)
	DECLARE @MeasureNew AS NVARCHAR(50)
	DECLARE @PriceNew AS DECIMAL(10, 2)
	SELECT @DescriptionNew = I.[Description], @CategoryIdNew = I.[CategoryId], @SupplierIdNew = I.[SupplierId],
			@BrandNew = I.[Brand], @ModelNew = I.[Model], @MeasureNew = I.[Measure], @PriceNew = I.[Price] FROM deleted AS I
	
	INSERT INTO [dbo].[ProductHistory]
	VALUES(GETDATE(), @ProductId, @DescriptionOld, @DescriptionNew, @CategoryIdOld, @CategoryIdNew, @SupplierIdOld,
			@SupplierIdNew, @BrandOld, @BrandNew, @ModelOld, @ModelNew, @MeasureOld, @MeasureNew, @PriceOld, @PriceNew)
END
GO