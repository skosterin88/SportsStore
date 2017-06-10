CREATE TABLE [dbo].[attribute_values_text] (
    [ProductId]   INT            NOT NULL,
    [AttributeId] INT            NOT NULL,
    [Value]       NVARCHAR (MAX) NULL,
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[products] ([Id]),
    FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[attributes] ([Id])
);

