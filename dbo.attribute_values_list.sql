CREATE TABLE [dbo].[attribute_values_list] (
    [ProductId]   INT NOT NULL,
    [AttributeId] INT NOT NULL,
    [Value]       INT NULL,
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[products] ([Id]),
    FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[attributes] ([Id]),
    FOREIGN KEY ([Value]) REFERENCES [dbo].[list_items] ([Id])
);

