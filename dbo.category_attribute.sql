CREATE TABLE [dbo].[category_attribute] (
    [CategoryId]        INT NOT NULL,
    [AttributeId]       INT NOT NULL,
    [VisualizationMode] INT NULL,
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[categories] ([Id]),
    FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[attributes] ([Id])
);

