CREATE TABLE [dbo].[attribute_values_float] (
    [ProductId]   INT        NOT NULL,
    [AttributeId] INT        NOT NULL,
    [Value]       FLOAT (53) NULL,
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[products] ([Id]),
    FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[attributes] ([Id])
);

