USE DataTableValidation
GO

SELECT * FROM dbo.RuleTableCollection
GO

TRUNCATE TABLE dbo.RuleTableCollection
GO

-- B01/BCTC-TH (BÁO CÁO TÌNH HÌNH TÀI CHÍNH TỔNG HỢP)
INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_01_SoDauNam',   -- ValidateCell - varchar(50)
    '>=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_10_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_11_SoDauNam + A_12_SoDauNam + A_14_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_20_SoDauNam',   -- ValidateCell - varchar(50)
    '>=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_30_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_31_SoDauNam + A_35_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_31_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_32_SoDauNam + A_33_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_33_SoDauNam',   -- ValidateCell - varchar(50)
    '<=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_35_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_36_SoDauNam + A_37_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_37_SoDauNam',   -- ValidateCell - varchar(50)
    '<=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_50_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_80_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_50_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_01_SoDauNam + A_05_SoDauNam + A_10_SoDauNam + A_20_SoDauNam + A_25_SoDauNam + A_30_SoDauNam + A_40_SoDauNam + A_45_SoDauNam + A_46_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_60_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_61_SoDauNam + A_62_SoDauNam + A_64_SoDauNam + A_65_SoDauNam + A_66_SoDauNam + A_67_SoDauNam + A_68_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_70_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_71_SoDauNam + A_72_SoDauNam + A_73_SoDauNam + A_74_SoDauNam + A_75_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_80_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_50_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_80_SoDauNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_60_SoDauNam + A_70_SoDauNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

-- ///////////////////////////////////
INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_01_SoCuoiNam',   -- ValidateCell - varchar(50)
    '>=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_10_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_11_SoCuoiNam + A_12_SoCuoiNam + A_14_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_20_SoCuoiNam',   -- ValidateCell - varchar(50)
    '>=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_30_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_31_SoCuoiNam + A_35_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_31_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_32_SoCuoiNam + A_33_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_33_SoCuoiNam',   -- ValidateCell - varchar(50)
    '<=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_35_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_36_SoCuoiNam + A_37_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_37_SoCuoiNam',   -- ValidateCell - varchar(50)
    '<=',   -- VOperator - varchar(50)
    '0',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_50_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_80_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_50_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_01_SoCuoiNam + A_05_SoCuoiNam + A_10_SoCuoiNam + A_20_SoCuoiNam + A_25_SoCuoiNam + A_30_SoCuoiNam + A_40_SoCuoiNam + A_45_SoCuoiNam + A_46_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_60_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_61_SoCuoiNam + A_62_SoCuoiNam + A_64_SoCuoiNam + A_65_SoCuoiNam + A_66_SoCuoiNam + A_67_SoCuoiNam + A_68_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_70_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_71_SoCuoiNam + A_72_SoCuoiNam + A_73_SoCuoiNam + A_74_SoCuoiNam + A_75_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_80_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_50_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)

INSERT dbo.RuleTableCollection ( Id, ReportCode, ValidateCell, VOperator, CompareExpression, ErrorMessage )
VALUES
(   NEWID(), -- Id - uniqueidentifier
    'B01/BCTC-TH',   -- ReportCode - varchar(50)
    'A_80_SoCuoiNam',   -- ValidateCell - varchar(50)
    '=',   -- VOperator - varchar(50)
    'A_60_SoCuoiNam + A_70_SoCuoiNam',   -- CompareExpression - varchar(500)
    N''   -- ErrorMessage - nvarchar(500)
)
 